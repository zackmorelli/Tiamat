using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using System.Threading;
using System.Windows.Controls;



/*
    Tiamat - Automatic plan creation/beam setup script

    Description:
    This is the Script Execute start-up file for the Tiamat program.
    This program is named after Tiamat, the Babylonian goddess of creation. It was meant to be an automatic RT plan creation script, but was drastically scaled back.
    It is currently configured to only add imaging setup beams to a plan. There is a lot of other code here that is not being used. Please refer to the README for more information.
    This script is currently a write-approved program in the clinical Eclipse system aso of 1/17/2022.

   
    This program is expressely written as a plug-in script for use with Varian's Eclipse Treatment Planning System, and requires Varian's API files to run properly.
    This program runs on .NET Framework 4.6.1. 
    Copyright (C) 2022 Zackary Thomas Ricci Morelli
    
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

    I can be contacted at: zackmorelli@gmail.com


    Release 2.0.0.4 - 6/1/2021



*/

// Global assembly commands
[assembly: ESAPIScript(IsWriteable = true)]   //Extremely important, makes scripts write-capable


namespace VMS.TPS
{
    public class Script     //Everything within the Varian script class
    {
        public Script() { }  // instantiates a Script class

        // Assembly Commands (I guess this is specific to the Script class)
        [MethodImpl(MethodImplOptions.NoInlining)]       // prevents compiler optimization from messing with the program's methods. 

        //Execute function of the script
        public void Execute(ScriptContext context)     // PROGRAM START - sending a return to Execute will end the program
        {
            // guess we can do everything in execute for now
            //MessageBox.Show("Program Start");

            Patient patient = context.Patient;   // creates an object of the patient class called patient equal to the active patient open in Eclipse
            Course course = context.Course;
            ExternalPlanSetup plan = context.ExternalPlanSetup;
            VMS.TPS.Common.Model.API.Image image3D = context.Image;
            StructureSet structureset = context.StructureSet;
            User user = context.CurrentUser;

            try
            {
                string strctid = plan.StructureSet.Id;
            }
            catch (NullReferenceException e)
            {
                MessageBox.Show("The plan " + plan.Id + " does not have a structure set! Tiamat requires a structure set.\n\nThe program will now close.");
                // no structure set, skip
                return;
            }

            if (plan.PlanType == PlanType.Brachy)
            {
                MessageBox.Show("Sorry, the Tiamat is currently only designed for External Beam plans.\n\nThe program will now close.");
                return;
            }


            // now, need to run the GUI to get user info
            System.Windows.Forms.Form InitialTiamatGUIForm = new Tiamat.InitialTiamatGUI(patient, course, structureset, plan, user);
            System.Windows.Forms.Application.Run(InitialTiamatGUIForm);

            // apparently the application.Run will wait until the form closes

            //if (InitialTiamatGUIForm.IsDisposed)
            //{
            //    if (UI[0] != null && UI[1] != null && UI[2] != null && UI[3] != null)
            //    {
            //        //MessageBox.Show("Form Disposed.");
            //        TiamatExecute(UI, patient, course, structureSet, plan, user);
            //    }
            //    else
            //    {
            //        MessageBox.Show("A value is required for Linac, Treatment Site, Treatment Technique, and Laterality.");
            //    }
            //}

            return;
        }  //ends Execute  END OF PROGRAM


       


    }
}
