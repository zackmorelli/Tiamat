using System;
using g3;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using System.Windows.Media.Media3D;
using CollisionCheck;
using System.Collections;
using System.Diagnostics;

namespace Tiamat
{
    class TiamatMethods
    {
        public static void AddBeams(string[] UI, ExternalPlanSetup plan)
        {
           // MessageBox.Show("Start Add Beams");

            // UI O - Linac
            // UI 1 - Treatment Technique
            // UI 2 - Treatment Site
            // UI 3 - Laterality
            // UI 4 - SetupBeams
            // UI 5 - Optimize
            // UI 6 - Rapidplan
            // UI 7 - DoseCalc
            // UI 8 - Acuros Algo
            // UI 9 - DVH analysis
            // UI 10 - Trade-off analysis
            // UI 11 - leaf motion
            // UI 12 - QA plan

            string Linac = UI[0];
            string Laterality = UI[3];
            string TXtechnique = UI[1];

            VVector Iso = new VVector(plan.StructureSet.Image.UserOrigin.x, plan.StructureSet.Image.UserOrigin.y, plan.StructureSet.Image.UserOrigin.z);


            //MessageBox.Show("Start BeamConfig list.");

            //string machineID, string EnergyModeId ("6X, 18X"), int DoseRate, string TechniqueId ("STATIC", or "ARC"), string PrimaryFluenceModeId (NULL, empty, "SRS", or "FFF")  
            //ExternalBeamMachineParameters mparam = new ExternalBeamMachineParameters("21EX", "6X", 600, "STATIC", "");  // Just guesses. need to look in the scripting help in Eclipse on the TBOX to try and figure out what exactly this is supposed to take

            //Beam newbeam = plan.AddStaticBeam(mparam, new VRect<double>(5.0, 5.0, 5.0, 5.0), 0.0, 0.0, 0.0, plan.PrimaryReferencePoint.GetReferencePointLocation(plan));

            //newbeam.Id = "beamname";

            //try
            //{
            //    plan.AddArcBeam(mparam, beamconfig.BeamArray[Be].JawPositions, beamconfig.BeamArray[Be].CollimatorAngle, beamconfig.BeamArray[Be].GantryStartAngle, beamconfig.BeamArray[Be].GantryStopAngle, beamconfig.BeamArray[Be].GantryDirection, beamconfig.BeamArray[Be].CouchAngle, plan.PrimaryReferencePoint.GetReferencePointLocation(plan));
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Issue with AddArcBeam\n\n\n" + e.ToString() + "\n\n\n" + e.StackTrace + "\n\n\n" + e.InnerException + "\n\n\n" + e.Source);
            //}
            //break;

            //MessageBox.Show("Start Beam Config.");


            // adds treatment beams using the parameters selected by user
            switch (UI[2])
            {
                case "Prostate":

                    break;

                case "Head & Neck":

                    //var HNdrr = new DRRCalculationParameters(500);   // DRR size in mm (always 500)
                   // HNdrr.SetLayerParameters(0, 1, -990, 918, 1, 5);  //index, layer weight, low end of CT Window, High end of CT Window, start distance from iso, end distance from iso ( in mm)
                    //Abddrr.SetLayerParameters(1, 10, 100, 1000);

                    //// now add imaging beams, if requested
                    if (UI[4] == "SetupBeams - Y")
                    {
                        ExternalBeamMachineParameters pmSet = new ExternalBeamMachineParameters(Linac, "6X", 600, "STATIC", "");
                        Beam SetCBCT = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
                        SetCBCT.Id = "CBCT";
                        //SetCBCT.CreateOrReplaceDRR(HNdrr);

                        Beam SetKV0 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
                        //SetKV0.CreateOrReplaceDRR(HNdrr);

                        Beam SetMV0 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
                        //SetMV0.CreateOrReplaceDRR(HNdrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
                        {
                            SetKV0.Id = "Ant Kv";
                            //SetKV0.Name = "Ant Kv";
                            SetMV0.Id = "Ant Mv";
                            //SetMV0.Name = "Ant Mv";
                        }
                        else
                        {
                            SetKV0.Id = "Pa Kv";
                            //SetKV0.Name = "Pa Kv";
                            SetMV0.Id = "Pa MV";
                            //SetMV0.Name = "Pa Mv";
                        }

                        Beam SetKV90 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 90.0, 0.0, Iso);
                        //SetKV90.CreateOrReplaceDRR(HNdrr);

                        Beam SetMV90 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 90.0, 0.0, Iso);
                        //SetMV90.CreateOrReplaceDRR(HNdrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
                        {
                            SetKV90.Id = "R Lat Kv";
                            //SetKV90.Name = "R Lat Kv";
                            SetMV90.Id = "R Lat Mv";
                            //SetMV90.Name = "R Lat Mv";
                        }
                        else
                        {
                            SetKV90.Id = "L Lat Kv";
                            //SetKV90.Name = "L Lat Kv";
                            SetMV90.Id = "L Lat Mv";
                            //SetMV90.Name = "L Lat Mv";
                        }

                        Beam SetKV180 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 180.0, 0.0, Iso);
                        //SetKV180.CreateOrReplaceDRR(HNdrr);

                        Beam SetMV180 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 180.0, 0.0, Iso);
                        //SetMV180.CreateOrReplaceDRR(HNdrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
                        {
                            SetKV180.Id = "Pa Kv";
                            //SetKV180.Name = "Pa Kv";
                            SetMV180.Id = "Pa Mv";
                            //SetMV180.Name = "Pa Mv";
                        }
                        else
                        {
                            SetKV180.Id = "Ant Kv";
                            //SetKV180.Name = "Ant Kv";
                            SetMV180.Id = "Ant Mv";
                            //SetMV180.Name = "Ant Mv";
                        }

                        Beam SetKV270 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 270.0, 0.0, Iso);
                        //SetKV270.CreateOrReplaceDRR(HNdrr);

                        Beam SetMV270 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 270.0, 0.0, Iso);
                        //SetMV270.CreateOrReplaceDRR(HNdrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
                        {
                            SetKV270.Id = "L Lat Kv";
                            //SetKV270.Name = "L Lat Kv";
                            SetMV270.Id = "L Lat Mv";
                            //SetMV270.Name = "L Lat Mv";
                        }
                        else
                        {
                            SetKV270.Id = "R Lat Kv";
                            //SetKV270.Name = "R Lat Kv";
                            SetMV270.Id = "R Lat Mv";
                            //SetMV270.Name = "R Lat Mv";
                        }
                    }

                    switch (Laterality)
                    {
                        case "Right":

                            switch (TXtechnique)
                            {
                                case "3-Arc VMAT":

                                    ExternalBeamMachineParameters HN3Rp = new ExternalBeamMachineParameters(Linac, "6X", 600, "ARC", "");

                                    Beam HN3R_1 = plan.AddArcBeam(HN3Rp, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 30.0, 191.0, 30.0, GantryDirection.Clockwise, 0.0, Iso);
                                    HN3R_1.Id = "Arc_191_30";
                                    //HN3R_1.Name = "Arc_191_300";
                                    //HN3R_1.CreateOrReplaceDRR(HNdrr);

                                    Beam HN3R_2 = plan.AddArcBeam(HN3Rp, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 330.0, 29.0, 190.0, GantryDirection.CounterClockwise, 0.0, Iso);
                                    HN3R_2.Id = "Arc_29_190";
                                    //HN3R_2.Name = "Arc_29_190";
                                    //HN3R_2.CreateOrReplaceDRR(HNdrr);

                                    Beam HN3R_3 = plan.AddArcBeam(HN3Rp, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 105.0, 191.0, 30.0, GantryDirection.Clockwise, 0.0, Iso);
                                    HN3R_3.Id = "Arc2_191_30";
                                    //HN3R_3.Name = "Arc2_191_30";
                                    //HN3R_3.CreateOrReplaceDRR(HNdrr);

                                    break;
                            }
                            break;

                        case "Left":

                            switch (TXtechnique)
                            {
                                case "3-Arc VMAT":

                                    ExternalBeamMachineParameters HN3Lp = new ExternalBeamMachineParameters(Linac, "6X", 600, "ARC", "");

                                    Beam HN3L_1 = plan.AddArcBeam(HN3Lp, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 30.0, 330.0, 171.0, GantryDirection.Clockwise, 0.0, Iso);
                                    HN3L_1.Id = "Arc_330_171";
                                    //HN3L_1.Name = "Arc_330_171";
                                    //HN3L_1.CreateOrReplaceDRR(HNdrr);

                                    Beam HN3L_2 = plan.AddArcBeam(HN3Lp, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 330.0, 171.0, 331.0, GantryDirection.CounterClockwise, 0.0, Iso);
                                    HN3L_2.Id = "Arc_171_331";
                                    //HN3L_2.Name = "Arc_171_331";
                                    //HN3L_2.CreateOrReplaceDRR(HNdrr);

                                    Beam HN3L_3 = plan.AddArcBeam(HN3Lp, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 105.0, 330.0, 171.0, GantryDirection.Clockwise, 0.0, Iso);
                                    HN3L_3.Id = "Arc2_330_171";
                                    //HN3L_3.Name = "Arc2_330_171";
                                    //HN3L_3.CreateOrReplaceDRR(HNdrr);

                                    break;
                            }

                            break;

                        case "Bilateral":

                            switch (TXtechnique)
                            {
                                case "3-Arc VMAT":

                                    ExternalBeamMachineParameters HN3Bp = new ExternalBeamMachineParameters(Linac, "6X", 600, "ARC", "");

                                    Beam HN3B_1 = plan.AddArcBeam(HN3Bp, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 30.0, 191.0, 170.0, GantryDirection.Clockwise, 0.0, Iso);
                                    HN3B_1.Id = "Arc_191_170";
                                    //HN3B_1.Name = "Arc_191_170";
                                    //HN3B_1.CreateOrReplaceDRR(HNdrr);

                                    Beam HN3B_2 = plan.AddArcBeam(HN3Bp, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 330.0, 171.0, 190.0, GantryDirection.CounterClockwise, 0.0, Iso);
                                    HN3B_2.Id = "Arc_171_190";
                                    //HN3B_2.Name = "Arc_171_190";
                                    //HN3B_2.CreateOrReplaceDRR(HNdrr);

                                    Beam HN3B_3 = plan.AddArcBeam(HN3Bp, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 105.0, 191.0, 170.0, GantryDirection.Clockwise, 0.0, Iso);
                                    HN3B_3.Id = "Arc2_191_170";
                                    //HN3B_3.Name = "Arc2_191_170";
                                    //HN3B_3.CreateOrReplaceDRR(HNdrr);

                                    break;
                            }

                            break;
                    }

                    break;

                case "Abdomen":

                    //var Abddrr = new DRRCalculationParameters(500);   // DRR size in mm (always 500)
                    //Abddrr.SetLayerParameters(0, 2, -16, 126, 2, 6);  //index, layer weight, low end of CT Window, High end of CT Window, start distance from iso, end distance from iso ( in mm)
                    //Abddrr.SetLayerParameters(1, 10, 100, 1000);

                    //// now add imaging beams, if requested
                    if (UI[4] == "SetupBeams - Y")
                    {
                        ExternalBeamMachineParameters pmSet = new ExternalBeamMachineParameters(Linac, "6X", 600, "STATIC", "");

                        Beam SetCBCT = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
                        SetCBCT.Id = "CBCT";
                        //SetCBCT.CreateOrReplaceDRR(Abddrr);

                        Beam SetKV0 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
                        //SetKV0.CreateOrReplaceDRR(Abddrr);

                        Beam SetMV0 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
                        //SetMV0.CreateOrReplaceDRR(Abddrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
                        {
                            SetKV0.Id = "Ant Kv";
                            //SetKV0.Name = "Ant Kv";
                            SetMV0.Id = "Ant Mv";
                            //SetMV0.Name = "Ant Mv";
                        }
                        else
                        {
                            SetKV0.Id = "Pa Kv";
                            //SetKV0.Name = "Pa Kv";
                            SetMV0.Id = "Pa MV";
                            //SetMV0.Name = "Pa Mv";
                        }

                        Beam SetKV90 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 90.0, 0.0, Iso);
                        //SetKV90.CreateOrReplaceDRR(Abddrr);

                        Beam SetMV90 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 90.0, 0.0, Iso);
                        //SetMV90.CreateOrReplaceDRR(Abddrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
                        {
                            SetKV90.Id = "R Lat Kv";
                            //SetKV90.Name = "R Lat Kv";
                            SetMV90.Id = "R Lat Mv";
                            //SetMV90.Name = "R Lat Mv";
                        }
                        else
                        {
                            SetKV90.Id = "L Lat Kv";
                            //SetKV90.Name = "L Lat Kv";
                            SetMV90.Id = "L Lat Mv";
                            //SetMV90.Name = "L Lat Mv";
                        }

                        Beam SetKV180 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 180.0, 0.0, Iso);
                        //SetKV180.CreateOrReplaceDRR(Abddrr);

                        Beam SetMV180 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 180.0, 0.0, Iso);
                        //SetMV180.CreateOrReplaceDRR(Abddrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
                        {
                            SetKV180.Id = "Pa Kv";
                            //SetKV180.Name = "Pa Kv";
                            SetMV180.Id = "Pa Mv";
                            //SetMV180.Name = "Pa Mv";
                        }
                        else
                        {
                            SetKV180.Id = "Ant Kv";
                            //SetKV180.Name = "Ant Kv";
                            SetMV180.Id = "Ant Mv";
                            //SetMV180.Name = "Ant Mv";
                        }

                        Beam SetKV270 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 270.0, 0.0, Iso);
                        //SetKV270.CreateOrReplaceDRR(Abddrr);

                        Beam SetMV270 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 270.0, 0.0, Iso);
                        //SetMV270.CreateOrReplaceDRR(Abddrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
                        {
                            SetKV270.Id = "L Lat Kv";
                            //SetKV270.Name = "L Lat Kv";
                            SetMV270.Id = "L Lat Mv";
                            //SetMV270.Name = "L Lat Mv";
                        }
                        else
                        {
                            SetKV270.Id = "R Lat Kv";
                            //SetKV270.Name = "R Lat Kv";
                            SetMV270.Id = "R Lat Mv";
                            //SetMV270.Name = "R Lat Mv";
                        }
                    }

                    switch (TXtechnique)
                    {
                        case "9-field static":
                            // 9 static beams
                            //MessageBox.Show("Abdomen 9-field static");

                            ExternalBeamMachineParameters Abd9p = new ExternalBeamMachineParameters(Linac, "6X", 600, "STATIC", "");

                            Beam Abd9_1 = plan.AddStaticBeam(Abd9p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 200.0, 0.0, Iso);
                            //Abd9_1.CreateOrReplaceDRR(Abddrr);
                            Abd9_1.Id = "Static_200";
                           // Abd9_1.Name = "Static_200";
                            Beam Abd9_2 = plan.AddStaticBeam(Abd9p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 240.0, 0.0, Iso);
                            //Abd9_2.CreateOrReplaceDRR(Abddrr);
                            Abd9_2.Id = "Static_240";
                            //Abd9_2.Name = "Static_240";
                            Beam Abd9_3 = plan.AddStaticBeam(Abd9p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 280.0, 0.0, Iso);
                            //Abd9_3.CreateOrReplaceDRR(Abddrr);
                            Abd9_3.Id = "Static_280";
                           // Abd9_3.Name = "Static_280";
                            Beam Abd9_4 = plan.AddStaticBeam(Abd9p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 320.0, 0.0, Iso);
                            //Abd9_4.CreateOrReplaceDRR(Abddrr);
                            Abd9_4.Id = "Static_320";
                            //Abd9_4.Name = "Static_320";
                            Beam Abd9_5 = plan.AddStaticBeam(Abd9p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 0.0, 0.0, Iso);
                           // Abd9_5.CreateOrReplaceDRR(Abddrr);
                            Abd9_5.Id = "Static_0";
                            //Abd9_5.Name = "Static_0";
                            Beam Abd9_6 = plan.AddStaticBeam(Abd9p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 40.0, 0.0, Iso);
                            //Abd9_6.CreateOrReplaceDRR(Abddrr);
                            Abd9_6.Id = "Static_40";
                            //Abd9_6.Name = "Static_40";
                            Beam Abd9_7 = plan.AddStaticBeam(Abd9p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 80.0, 0.0, Iso);
                            //Abd9_7.CreateOrReplaceDRR(Abddrr);
                            Abd9_7.Id = "Static_80";
                           // Abd9_7.Name = "Static_80";
                            Beam Abd9_8 = plan.AddStaticBeam(Abd9p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 120.0, 0.0, Iso);
                            //Abd9_8.CreateOrReplaceDRR(Abddrr);
                            Abd9_8.Id = "Static_120";
                            //Abd9_8.Name = "Static_122";
                            Beam Abd9_9 = plan.AddStaticBeam(Abd9p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 160.0, 0.0, Iso);
                            //Abd9_9.CreateOrReplaceDRR(Abddrr);
                            Abd9_9.Id = "Static_160";
                            //Abd9_9.Name = "Static_160";
  
                            break;

                        case "2-Arc VMAT":
                            // 2 VMAT Beams

                            ExternalBeamMachineParameters Abd2p = new ExternalBeamMachineParameters(Linac, "6X", 600, "ARC", "");

                            Beam Abd2_1 = plan.AddArcBeam(Abd2p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 30.0, 191.0, 170.0, GantryDirection.Clockwise, 0.0, Iso);
                            Abd2_1.Id = "Arc_191_170";
                            //Abd2_1.Name = "Arc_191_170";
                            //Abd2_1.CreateOrReplaceDRR(Abddrr);

                            Beam Abd2_2 = plan.AddArcBeam(Abd2p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 330.0, 171.0, 190.0, GantryDirection.CounterClockwise, 0.0, Iso);
                            Abd2_2.Id = "Arc_171_190";
                            //Abd2_2.Name = "Arc_171_190";
                           // Abd2_2.CreateOrReplaceDRR(Abddrr);

                            break;
                    }

                    break;

                case "Lung":

                    //var Ldrr = new DRRCalculationParameters(500);   // DRR size in mm (always 500)
                    //Ldrr.SetLayerParameters(0, 1, -990, 918, 1, 5);  //index, layer weight, low end of CT Window, High end of CT Window, start distance from iso, end distance from iso ( in mm)
                                                                     //Abddrr.SetLayerParameters(1, 10, 100, 1000);

                    //// now add imaging beams, if requested
                    if (UI[4] == "SetupBeams - Y")
                    {
                        ExternalBeamMachineParameters pmSet = new ExternalBeamMachineParameters(Linac, "6X", 600, "STATIC", "");

                        Beam SetCBCT = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
                        SetCBCT.Id = "CBCT";
                        //SetCBCT.CreateOrReplaceDRR(Ldrr);

                        Beam SetKV0 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
                        //SetKV0.CreateOrReplaceDRR(Ldrr);

                        Beam SetMV0 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
                        //SetMV0.CreateOrReplaceDRR(Ldrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
                        {
                            SetKV0.Id = "Ant Kv";
                            //SetKV0.Name = "Ant Kv";
                            SetMV0.Id = "Ant Mv";
                            //SetMV0.Name = "Ant Mv";
                        }
                        else
                        {
                            SetKV0.Id = "Pa Kv";
                            //SetKV0.Name = "Pa Kv";
                            SetMV0.Id = "Pa MV";
                            //SetMV0.Name = "Pa Mv";
                        }

                        Beam SetKV90 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 90.0, 0.0, Iso);
                        //SetKV90.CreateOrReplaceDRR(Ldrr);

                        Beam SetMV90 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 90.0, 0.0, Iso);
                        //SetMV90.CreateOrReplaceDRR(Ldrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
                        {
                            SetKV90.Id = "R Lat Kv";
                            //SetKV90.Name = "R Lat Kv";
                            SetMV90.Id = "R Lat Mv";
                            //SetMV90.Name = "R Lat Mv";
                        }
                        else
                        {
                            SetKV90.Id = "L Lat Kv";
                            //SetKV90.Name = "L Lat Kv";
                            SetMV90.Id = "L Lat Mv";
                            //SetMV90.Name = "L Lat Mv";
                        }

                        Beam SetKV180 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 180.0, 0.0, Iso);
                        //SetKV180.CreateOrReplaceDRR(Ldrr);

                        Beam SetMV180 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 180.0, 0.0, Iso);
                        //SetMV180.CreateOrReplaceDRR(Ldrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
                        {
                            SetKV180.Id = "Pa Kv";
                            //SetKV180.Name = "Pa Kv";
                            SetMV180.Id = "Pa Mv";
                            //SetMV180.Name = "Pa Mv";
                        }
                        else
                        {
                            SetKV180.Id = "Ant Kv";
                            //SetKV180.Name = "Ant Kv";
                            SetMV180.Id = "Ant Mv";
                            //SetMV180.Name = "Ant Mv";
                        }

                        Beam SetKV270 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 270.0, 0.0, Iso);
                        //SetKV270.CreateOrReplaceDRR(Ldrr);

                        Beam SetMV270 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 270.0, 0.0, Iso);
                        //SetMV270.CreateOrReplaceDRR(Ldrr);

                        if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
                        {
                            SetKV270.Id = "L Lat Kv";
                            //SetKV270.Name = "L Lat Kv";
                            SetMV270.Id = "L Lat Mv";
                            //SetMV270.Name = "L Lat Mv";
                        }
                        else
                        {
                            SetKV270.Id = "R Lat Kv";
                            //SetKV270.Name = "R Lat Kv";
                            SetMV270.Id = "R Lat Mv";
                            //SetMV270.Name = "R Lat Mv";
                        }
                    }

                    switch (Laterality)
                    {
                        case "Right":

                            switch (TXtechnique)
                            {
                                case "2-Arc VMAT":

                                    ExternalBeamMachineParameters LR2p = new ExternalBeamMachineParameters(Linac, "6X", 600, "ARC", "");

                                    Beam LR2_1 = plan.AddArcBeam(LR2p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 30.0, 191.0, 30.0, GantryDirection.Clockwise, 0.0, Iso);
                                    LR2_1.Id = "Arc_191_30";
                                    //LR2_1.Name = "Arc_191_30";
                                    //LR2_1.CreateOrReplaceDRR(Ldrr);

                                    Beam LR2_2 = plan.AddArcBeam(LR2p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 330.0, 25.0, 190.0, GantryDirection.CounterClockwise, 0.0, Iso);
                                    LR2_2.Id = "Arc_25_190";
                                    //LR2_2.Name = "Arc_25_190";
                                    //LR2_2.CreateOrReplaceDRR(Ldrr);

                                    break;

                                case "7-field Static":

                                    ExternalBeamMachineParameters LR7p = new ExternalBeamMachineParameters(Linac, "6X", 600, "STATIC", "");

                                    Beam LR7_1 = plan.AddStaticBeam(LR7p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 200.0, 0.0, Iso);
                                    //LR7_1.CreateOrReplaceDRR(Ldrr);
                                    LR7_1.Id = "Static_200";
                                    //LR7_1.Name = "Static_200";
                                    Beam LR7_2 = plan.AddStaticBeam(LR7p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 240.0, 0.0, Iso);
                                    //LR7_2.CreateOrReplaceDRR(Ldrr);
                                    LR7_2.Id = "Static_240";
                                    //LR7_2.Name = "Static_240";
                                    Beam LR7_3 = plan.AddStaticBeam(LR7p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 280.0, 0.0, Iso);
                                    //LR7_3.CreateOrReplaceDRR(Ldrr);
                                    LR7_3.Id = "Static_280";
                                    //LR7_3.Name = "Static_280";
                                    Beam LR7_4 = plan.AddStaticBeam(LR7p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 320.0, 0.0, Iso);
                                    //LR7_4.CreateOrReplaceDRR(Ldrr);
                                    LR7_4.Id = "Static_320";
                                    //LR7_4.Name = "Static_320";
                                    Beam LR7_5 = plan.AddStaticBeam(LR7p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 0.0, 0.0, Iso);
                                    //LR7_5.CreateOrReplaceDRR(Ldrr);
                                    LR7_5.Id = "Static_0";
                                    //LR7_5.Name = "Static_0";
                                    Beam LR7_6 = plan.AddStaticBeam(LR7p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 40.0, 0.0, Iso);
                                    //LR7_6.CreateOrReplaceDRR(Ldrr);
                                    LR7_6.Id = "Static_40";
                                    //LR7_6.Name = "Static_40";
                                    Beam LR7_7 = plan.AddStaticBeam(LR7p, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 15.0, 90.0, 0.0, Iso);
                                    //LR7_7.CreateOrReplaceDRR(Ldrr);
                                    LR7_7.Id = "Static_90";
                                    //LR7_7.Name = "Static_90";

                                    break;
                            }



                            break;

                        case "Left":

                            switch (TXtechnique)
                            {
                                case "2-Arc VMAT":

                                    ExternalBeamMachineParameters L2L = new ExternalBeamMachineParameters(Linac, "6X", 600, "ARC", "");

                                    Beam Abd2_1 = plan.AddArcBeam(L2L, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 30.0, 330.0, 170.0, GantryDirection.Clockwise, 0.0, Iso);
                                    Abd2_1.Id = "Arc_191_30";
                                    //Abd2_1.Name = "Arc_191_30";
                                    //Abd2_1.CreateOrReplaceDRR(Ldrr);

                                    Beam Abd2_2 = plan.AddArcBeam(L2L, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 330.0, 171.0, 330.0, GantryDirection.CounterClockwise, 0.0, Iso);
                                    Abd2_2.Id = "Arc_25_190";
                                    //Abd2_2.Name = "Arc_25_190";
                                    //Abd2_2.CreateOrReplaceDRR(Ldrr);

                                    break;

                                case "7-field Static":



                                    break;
                            }

                            break;


                        

                    }


                    break;





                // other cases will go here




   
            }





        }

        //=================================================================================================================================================================================================

        public static void AddGenericImagingBeams(string[] UI, ExternalPlanSetup plan)
        {
            //var Abddrr = new DRRCalculationParameters(500);   // DRR size in mm (always 500)
            //Abddrr.SetLayerParameters(0, 2, -16, 126, 2, 6);  //index, layer weight, low end of CT Window, High end of CT Window, start distance from iso, end distance from iso ( in mm)
            //Abddrr.SetLayerParameters(1, 10, 100, 1000);

            string Linac = UI[0];
            VVector Iso = new VVector();

            // this attempts to set the Iso used for making the imaging beams to the Iso of an existing treatment beam, in case it has been shifted from user origin
            // otherwise, use user origin as Iso
            try
            {
                Iso = plan.Beams.First(b => b.IsSetupField == false).IsocenterPosition;
            }
            catch
            {
                Iso = new VVector(plan.StructureSet.Image.UserOrigin.x, plan.StructureSet.Image.UserOrigin.y, plan.StructureSet.Image.UserOrigin.z);
            }
            finally
            {
                Iso = new VVector(plan.StructureSet.Image.UserOrigin.x, plan.StructureSet.Image.UserOrigin.y, plan.StructureSet.Image.UserOrigin.z);
            }

            //// now add imaging beams, if requested

            ExternalBeamMachineParameters pmSet = new ExternalBeamMachineParameters(Linac, "6X", 600, "STATIC", "");

            Beam SetCBCT = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
            SetCBCT.Id = "CBCT";
            //SetCBCT.CreateOrReplaceDRR(Abddrr);

            Beam SetKV0 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
            //SetKV0.CreateOrReplaceDRR(Abddrr);

            Beam SetMV0 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 0.0, 0.0, Iso);
            //SetMV0.CreateOrReplaceDRR(Abddrr);

            if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
            {
                SetKV0.Id = "Ant Kv";
                //SetKV0.Name = "Ant Kv";
                SetMV0.Id = "Ant Mv";
                //SetMV0.Name = "Ant Mv";
            }
            else
            {
                SetKV0.Id = "Pa Kv";
               // SetKV0.Name = "Pa Kv";
                SetMV0.Id = "Pa MV";
               // SetMV0.Name = "Pa Mv";
            }

            Beam SetKV90 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 90.0, 0.0, Iso);
           // SetKV90.CreateOrReplaceDRR(Abddrr);

            Beam SetMV90 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 90.0, 0.0, Iso);
           // SetMV90.CreateOrReplaceDRR(Abddrr);

            if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
            {
                SetKV90.Id = "R Lat Kv";
                //SetKV90.Name = "R Lat Kv";
                SetMV90.Id = "R Lat Mv";
               // SetMV90.Name = "R Lat Mv";
            }
            else
            {
                SetKV90.Id = "L Lat Kv";
              // SetKV90.Name = "L Lat Kv";
                SetMV90.Id = "L Lat Mv";
              //  SetMV90.Name = "L Lat Mv";
            }

            Beam SetKV180 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 180.0, 0.0, Iso);
            //SetKV180.CreateOrReplaceDRR(Abddrr);

            Beam SetMV180 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 180.0, 0.0, Iso);
            //SetMV180.CreateOrReplaceDRR(Abddrr);

            if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
            {
                SetKV180.Id = "Pa Kv";
                //SetKV180.Name = "Pa Kv";
                SetMV180.Id = "Pa Mv";
                //SetMV180.Name = "Pa Mv";
            }
            else
            {
                SetKV180.Id = "Ant Kv";
                //SetKV180.Name = "Ant Kv";
                SetMV180.Id = "Ant Mv";
                //SetMV180.Name = "Ant Mv";
            }

            Beam SetKV270 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 270.0, 0.0, Iso);
            //SetKV270.CreateOrReplaceDRR(Abddrr);

            Beam SetMV270 = plan.AddStaticBeam(pmSet, new VRect<double>(-50.0, -50.0, 50.0, 50.0), 0.0, 270.0, 0.0, Iso);
            //SetMV270.CreateOrReplaceDRR(Abddrr);

            if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine || plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
            {
                SetKV270.Id = "L Lat Kv";
                //SetKV270.Name = "L Lat Kv";
                SetMV270.Id = "L Lat Mv";
                //SetMV270.Name = "L Lat Mv";
            }
            else
            {
                SetKV270.Id = "R Lat Kv";
                //SetKV270.Name = "R Lat Kv";
                SetMV270.Id = "R Lat Mv";
                //SetMV270.Name = "R Lat Mv";
            }
        }


        //===================================================================================================================================================================================================================


        public static OptimizationObjective[] MakeOptimizationObjectives(string TXsite, string TXtechnique, string Linac, string Laterality, string OptObjSet)
        {
            OptimizationObjective[] optimizationObjectives = new OptimizationObjective[20];


            switch (TXsite)
            { 
                case "Abdomen":
                    optimizationObjectives = new OptimizationObjective[12];

                    optimizationObjectives[0] = new OptimizationObjective() {  StructureID = "_PTV_Hi", DoseValue = new DoseValue(6050, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Lower, Priority = 150, Volume = 100.0, ObjectiveType = "point"};
                    optimizationObjectives[1] = new OptimizationObjective() { StructureID = "_PTV_Hi", DoseValue = new DoseValue(6550, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 50, Volume = 0.0, ObjectiveType = "point"};
                    optimizationObjectives[2] = new OptimizationObjective() { StructureID = "CaudaEquina", DoseValue = new DoseValue(5500, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 25, Volume = 0.0, ObjectiveType = "point" };
                    optimizationObjectives[3] = new OptimizationObjective() { StructureID = "Jejunum", DoseValue = new DoseValue(4750, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 35, Volume = 5.0, ObjectiveType = "point" };
                    optimizationObjectives[4] = new OptimizationObjective() { StructureID = "Kidney_L", DoseValue = new DoseValue(1450, DoseValue.DoseUnit.cGy), Priority = 25, ObjectiveType = "mean" };
                    optimizationObjectives[5] = new OptimizationObjective() { StructureID = "Kidney_R", DoseValue = new DoseValue(1450, DoseValue.DoseUnit.cGy), Priority = 25, ObjectiveType = "mean" };
                    optimizationObjectives[6] = new OptimizationObjective() { StructureID = "LgBowel_Loops", DoseValue = new DoseValue(5300, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 25, Volume = 0.0, ObjectiveType = "point" };
                    optimizationObjectives[7] = new OptimizationObjective() { StructureID = "SmBowel_Loops", DoseValue = new DoseValue(4750, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 50, Volume = 5.0, ObjectiveType = "point" };
                    optimizationObjectives[8] = new OptimizationObjective() { StructureID = "SpinalCord", DoseValue = new DoseValue(4400, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 50, Volume = 0.0, ObjectiveType = "point" };
                    optimizationObjectives[9] = new OptimizationObjective() { StructureID = "Stomach", DoseValue = new DoseValue(4750, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 50, Volume = 5.0, ObjectiveType = "point" };
                    optimizationObjectives[10] = new OptimizationObjective() { StructureID = "Kidneys_Bilat", DoseValue = new DoseValue(1950, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 50, Volume = 25.0, ObjectiveType = "point" };
                    optimizationObjectives[11] = new OptimizationObjective() { StructureID = "Kidneys_Bilat", DoseValue = new DoseValue(1150, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 35, Volume = 50.0, ObjectiveType = "point" };
                    break;

                    //"H&N 7000 cGy",
                    //    "H&N 6996 cGy",
                    //    "H&N 6600 cGy"

                case "Head & Neck":
                    switch (OptObjSet)
                    {
                        case "H&N 7000 cGy":

                            optimizationObjectives = new OptimizationObjective[26];

                            optimizationObjectives[0] = new OptimizationObjective() { StructureID = "Eye_R", DoseValue = new DoseValue(4500, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 50, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[1] = new OptimizationObjective() { StructureID = "Eye_L", DoseValue = new DoseValue(4800, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 50, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[2] = new OptimizationObjective() { StructureID = "Esophagus", DoseValue = new DoseValue(3200, DoseValue.DoseUnit.cGy), Priority = 35, ObjectiveType = "mean" };
                            optimizationObjectives[3] = new OptimizationObjective() { StructureID = "Chiasm_Nerve_03", DoseValue = new DoseValue(5400, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 90, Volume = 5.0, ObjectiveType = "point" };
                            optimizationObjectives[4] = new OptimizationObjective() { StructureID = "Brainstem_03", DoseValue = new DoseValue(5450, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 90, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[5] = new OptimizationObjective() { StructureID = "Brainstem", DoseValue = new DoseValue(5300, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 120, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[6] = new OptimizationObjective() { StructureID = "Brain", DoseValue = new DoseValue(2750, DoseValue.DoseUnit.cGy), Priority = 50, ObjectiveType = "mean" };
                            optimizationObjectives[7] = new OptimizationObjective() { StructureID = "_PTV_Hi", DoseValue = new DoseValue(7000, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Lower, Priority = 0, Volume = 95.0, ObjectiveType = "point" };
                            optimizationObjectives[8] = new OptimizationObjective() { StructureID = "Larynx", DoseValue = new DoseValue(4200, DoseValue.DoseUnit.cGy), Priority = 50, ObjectiveType = "mean" };
                            optimizationObjectives[9] = new OptimizationObjective() { StructureID = "Lips", DoseValue = new DoseValue(4800, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 50, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[10] = new OptimizationObjective() { StructureID = "Mandible", DoseValue = new DoseValue(6800, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 75, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[11] = new OptimizationObjective() { StructureID = "OpticChiasm", DoseValue = new DoseValue(5200, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 120, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[12] = new OptimizationObjective() { StructureID = "OpticNerve_L", DoseValue = new DoseValue(4800, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 120, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[13] = new OptimizationObjective() { StructureID = "OpticNerve_R", DoseValue = new DoseValue(4800, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 120, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[14] = new OptimizationObjective() { StructureID = "OralCavity", DoseValue = new DoseValue(4700, DoseValue.DoseUnit.cGy), Priority = 35, ObjectiveType = "mean" };
                            optimizationObjectives[15] = new OptimizationObjective() { StructureID = "Parotid_L", DoseValue = new DoseValue(2300, DoseValue.DoseUnit.cGy), Priority = 90, ObjectiveType = "mean" };
                            optimizationObjectives[16] = new OptimizationObjective() { StructureID = "Parotid_R", DoseValue = new DoseValue(2300, DoseValue.DoseUnit.cGy), Priority = 90, ObjectiveType = "mean" };
                            optimizationObjectives[17] = new OptimizationObjective() { StructureID = "PharynxConstr", DoseValue = new DoseValue(4750, DoseValue.DoseUnit.cGy), Priority = 75, ObjectiveType = "mean" };
                            optimizationObjectives[18] = new OptimizationObjective() { StructureID = "SpinalCord", DoseValue = new DoseValue(4400, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 120, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[19] = new OptimizationObjective() { StructureID = "SpinalCord_05", DoseValue = new DoseValue(4800, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 90, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[20] = new OptimizationObjective() { StructureID = "zOpt_PTV_Low", DoseValue = new DoseValue(5750, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Lower, Priority = 150, Volume = 100.0, ObjectiveType = "point" };
                            optimizationObjectives[21] = new OptimizationObjective() { StructureID = "zOpt_PTV_Low", DoseValue = new DoseValue(5800, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 130, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[22] = new OptimizationObjective() { StructureID = "zOpt_PTV_Mid", DoseValue = new DoseValue(6075, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Lower, Priority = 150, Volume = 100.0, ObjectiveType = "point" };
                            optimizationObjectives[23] = new OptimizationObjective() { StructureID = "ZOpt_PTV_Mid", DoseValue = new DoseValue(6125, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 130, Volume = 0.0, ObjectiveType = "point" };
                            optimizationObjectives[24] = new OptimizationObjective() { StructureID = "zOpt_PTV_Hi", DoseValue = new DoseValue(7150, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Lower, Priority = 150, Volume = 100.0, ObjectiveType = "point" };
                            optimizationObjectives[25] = new OptimizationObjective() { StructureID = "zOpt_PTV_Hi", DoseValue = new DoseValue(7200, DoseValue.DoseUnit.cGy), ObjectiveOperator = OptimizationObjectiveOperator.Upper, Priority = 130, Volume = 0.0, ObjectiveType = "point" };
                           
                            break;

                        case "H&N 6996 cGy":





                            break;

                        case "H&N 6600 cGy":









                            break;













                    }





                    break;





            }


            return optimizationObjectives;
        }


        //=================================================================================================================================================================================================================================================================================================================

        public static void MakeQAPlan(Patient patient, ExternalPlanSetup plan, string Linac)
        {

            //Not capable of generating Portal Dosimetry QA plans that we actually use, so not using this for now
            string QAcourseId = "QA";
            List<Course> pcourses = patient.Courses.ToList();
            
            if (pcourses.Exists(c => c.Id.Equals("QA")))
            {
                QAcourseId = "QA2";
            }

            if (pcourses.Exists(c => c.Id.Equals("QA2")))
            {
                QAcourseId = "QA3";
            }

            if (pcourses.Exists(c => c.Id.Equals("QA3")))
            {
                QAcourseId = "QA4";
            }

            if (pcourses.Exists(c => c.Id.Equals("QA4")))
            {
                QAcourseId = "QA5";
            }
            //MessageBox.Show("Trig 3");

            Course QAcourse = patient.AddCourse();
            QAcourse.Id = QAcourseId;

            ExternalPlanSetup QAplan = QAcourse.AddExternalPlanSetupAsVerificationPlan(plan.StructureSet, plan);
            QAplan.Id = QAcourseId;

            //MessageBox.Show("Trig 4");
            QAplan.SetPrescription(1, plan.DosePerFraction, plan.TreatmentPercentage);
            //QAplan.SetTargetStructureIfNoDose(null, null);

            VVector ISO = plan.Beams.First().IsocenterPosition;
            string BeamType;
            string Technique = null;
            string Energy = null;
            string Fluence = null;
            int DoseRate = 0;
            double gantryAng = -50;  //currBm.ControlPoints.First().GantryAngle;
            double collAng = -50;    //currBm.ControlPoints.First().CollimatorAngle;
            double couchAng = 0.0;
            double MU = 0.0;
            IEnumerable<double> muSet;   //currBm.ControlPoints.Select(cp => cp.MetersetWeight).ToList();
            List<KeyValuePair<string, MetersetValue>> muValues = new List<KeyValuePair<string, MetersetValue>>();

            foreach (Beam beam in plan.Beams)
            {
                Energy = beam.EnergyModeDisplayName;
                muValues.Add(new KeyValuePair<string, MetersetValue>(beam.Id, beam.Meterset));

                if (Energy.Contains("SRS"))
                {
                    Fluence = "SRS";
                }
                else if (Energy.Contains("FFF"))
                {
                    Fluence = "FFF";
                }

                Technique = beam.Technique.ToString();
                DoseRate = beam.DoseRate;
                MU = beam.Meterset.Value;
                gantryAng = beam.ControlPoints.First().GantryAngle;
                collAng = beam.ControlPoints.First().CollimatorAngle;
                muSet = beam.ControlPoints.Select(cp => cp.MetersetWeight).ToList();

                ExternalBeamMachineParameters machParam = new ExternalBeamMachineParameters(Linac, Energy, DoseRate, Technique, Fluence);
                BeamType = DetermineBeamType(beam);
                Beam QABeam;

                if (BeamType == "StaticMLC")
                {
                    QABeam = QAplan.AddMLCBeam(machParam, new float[2, 60], new VRect<double>(-10.0, -10.0, 10.0, 10.0), collAng, gantryAng, couchAng, ISO);
                    QABeam.Id = beam.Id;
                    BeamParameters ctrPtParam = copyControlPoints(beam, QABeam);
                    QABeam.ApplyParameters(ctrPtParam);

   


                }
                else if (BeamType == "StaticSegWin")
                {
                    QABeam = QAplan.AddMultipleStaticSegmentBeam(machParam, muSet, collAng, gantryAng, couchAng, ISO);
                    QABeam.Id = beam.Id;
                    BeamParameters ctrPtParam = copyControlPoints(beam, QABeam);
                    QABeam.ApplyParameters(ctrPtParam);
                }
                else if (BeamType == "StaticSlidingWin")
                {
                    QABeam = QAplan.AddSlidingWindowBeam(machParam, muSet, collAng, gantryAng, couchAng, ISO);
                    QABeam.Id = beam.Id;
                    BeamParameters ctrPtParam = copyControlPoints(beam, QABeam);
                    QABeam.ApplyParameters(ctrPtParam);
                }
                else if (BeamType == "ConformalArc")
                {
                    QABeam = QAplan.AddConformalArcBeam(machParam, collAng, beam.ControlPoints.Count(), beam.ControlPoints.First().GantryAngle, beam.ControlPoints.Last().GantryAngle, beam.GantryDirection, couchAng, ISO);
                    QABeam.Id = beam.Id;
                    BeamParameters ctrPtParam = copyControlPoints(beam, QABeam);
                    QABeam.ApplyParameters(ctrPtParam);
                }
                else if (BeamType == "VMAT")
                {
                    QABeam = QAplan.AddVMATBeam(machParam, muSet, collAng, beam.ControlPoints.First().GantryAngle, beam.ControlPoints.Last().GantryAngle, beam.GantryDirection, couchAng, ISO);
                    QABeam.Id = beam.Id;
                    BeamParameters ctrPtParam = copyControlPoints(beam, QABeam);
                    QABeam.ApplyParameters(ctrPtParam);
                }
                else // null
                {

                }
            }

            //compute dose, to make sure MU values are present
            QAplan.PlanNormalizationValue = plan.PlanNormalizationValue;
            QAplan.SetCalculationModel(CalculationType.PhotonVolumeDose, plan.PhotonCalculationModel);
            Dictionary<string, string> currentplancalcmodels = plan.GetCalculationOptions(plan.PhotonCalculationModel);
            foreach (KeyValuePair<string, string> calcmodel in currentplancalcmodels)
            {
                QAplan.SetCalculationOption(plan.PhotonCalculationModel, calcmodel.Key, calcmodel.Value);
            }

            if (QAplan.Beams.Any(b => b.MLCPlanType == MLCPlanType.ArcDynamic || b.MLCPlanType == MLCPlanType.Static))
            {
                //QAplan.CalculateDose();  // Compute dose for non-IMRT type beams
                                         // Correct for MU by changing beam weighting
                foreach (Beam verifBm in QAplan.Beams)
                {
                    BeamParameters verifBmParam = verifBm.GetEditableParameters();
                    verifBmParam.WeightFactor = muValues.First(mv => mv.Key == verifBm.Id).Value.Value / verifBm.Meterset.Value;
                    verifBm.ApplyParameters(verifBmParam);
                }
            }
            // For all other IMRT plans
            else
            {
                //QAplan.CalculateDoseWithPresetValues(muValues);  // Compute dose for IMRT type beams
            }
        }

        public static string DetermineBeamType(Beam bm)
        {
            if ((bm.Technique.Id.ToString() == "STATIC" || bm.Technique.Id.ToString() == "SRS STATIC") && bm.MLCPlanType == MLCPlanType.Static)
            {
                return "StaticMLC";
            }
            else if ((bm.Technique.Id.ToString() == "STATIC" || bm.Technique.Id.ToString() == "SRS STATIC") && bm.MLCPlanType == MLCPlanType.DoseDynamic)
            {
                // Check if the MLC technique is Sliding Window or Segmental
                var lines = bm.CalculationLogs.FirstOrDefault(log => log.Category == "LMC");
                foreach (var line in lines.MessageLines)
                {
                    if (line.ToUpper().Contains("MULTIPLE STATIC SEGMENTS")) { return "StaticSegWin"; }
                    if (line.ToUpper().Contains("SLIDING WINDOW")) { return "StaticSlidingWin"; }
                    if (line.ToUpper().Contains("SLIDING-WINDOW")) { return "StaticSlidingWin"; }
                }
                return null;
            }
            else if ((bm.Technique.Id.ToString() == "ARC" || bm.Technique.Id.ToString() == "SRS ARC") && bm.MLCPlanType == MLCPlanType.ArcDynamic)
            {
                return "ConformalArc";
            }
            else if ((bm.Technique.Id.ToString() == "ARC" || bm.Technique.Id.ToString() == "SRS ARC") && bm.MLCPlanType == MLCPlanType.VMAT)
            {
                return "VMAT";
            }
            else
            {
                return null;
            }
        }

        private static BeamParameters copyControlPoints(Beam currBm, Beam verifBm)
        {
            BeamParameters verifBmParam = verifBm.GetEditableParameters();
            for (int i_CP = 0; i_CP < verifBm.ControlPoints.Count(); i_CP++)
            {
                verifBmParam.ControlPoints.ElementAt(i_CP).LeafPositions = currBm.ControlPoints.ElementAt(i_CP).LeafPositions;
                verifBmParam.ControlPoints.ElementAt(i_CP).JawPositions = currBm.ControlPoints.ElementAt(i_CP).JawPositions;
            }
            verifBmParam.WeightFactor = currBm.WeightFactor;
            return verifBmParam;
        }

        public static void TiamatPlancheckExecute(PlanSetup plan, Patient patient, User user1, string laterality)
        {

            //Variable declaration space
            bool nogood = false;
            //this is used to signify that this plan is missing something needed for the program to run properly and is used to stop the handoff to PLANCHECK. 
            //Image image = context.Image;

            //populate my own classes with ESAPI info in order to completley isolate ESAPI, that way we can multi-thread.
            // that requires figuring out a lot of stuff here though before we call the GUI (on its own thread)

            string user = user1.Name;
            string progtype = "tiamat";
            PLANCHECK.PLAN CHPLAN = new PLANCHECK.PLAN();

            try
            {
                // this is all stuff for the PDF Report
                string patientId = plan.Course.Patient.Id;
                string patientsex = plan.Course.Patient.Sex;
                string courseId = plan.Course.Id;
                string PatFirstName = plan.Course.Patient.FirstName;
                string PatLastName = plan.Course.Patient.LastName;
                DateTime? PatDOB = plan.Course.Patient.DateOfBirth;
                string DocName = plan.Course.Patient.PrimaryOncologistId;
                string HospitalName = plan.Course.Patient.Hospital.Name;
                string HospitalAddress = plan.Course.Patient.Hospital.Location;
                string ApprovalStatus = plan.ApprovalStatus.ToString();
                DateTime? CreationDateTime = plan.CreationDateTime;
                string CreationUser = plan.CreationUserName;
                DateTime LastModifiedDateTime = plan.HistoryDateTime;
                string LastModifiedUser = plan.HistoryUserName;
                // string TreatmentSite 

                List<PLANCHECK.STRUCTURE> StructureSet = new List<PLANCHECK.STRUCTURE>();
                List<Vector3d> VertexList = new List<Vector3d>();
                Vector3d CP = new Vector3d();
                List<int> IndexList = new List<int>();

                foreach (Structure STR in plan.StructureSet.Structures)
                {
                    if (STR.IsEmpty == true || STR.Volume < 0.0)
                    {
                        //System.Windows.Forms.MessageBox.Show("The Couch Interior structure is not contoured!");
                        continue;
                    }

                    VertexList.Clear();
                    IndexList.Clear();

                    foreach (Point3D p in STR.MeshGeometry.Positions)
                    {
                        Vector3d vect = new Vector3d(p.X, p.Y, p.Z);
                        VertexList.Add(vect);
                    }

                    foreach (int I in STR.MeshGeometry.TriangleIndices)
                    {
                        IndexList.Add(I);
                    }

                    CP = new Vector3d(STR.CenterPoint.x, STR.CenterPoint.y, STR.CenterPoint.z);

                    Tuple<double, double, double> Bounds = new Tuple<double, double, double>(STR.MeshGeometry.Bounds.SizeX, STR.MeshGeometry.Bounds.SizeY, STR.MeshGeometry.Bounds.SizeZ);

                    StructureSet.Add(new PLANCHECK.STRUCTURE(VertexList, IndexList, CP, STR.Id, STR.DicomType, Bounds));
                }

                if (StructureSet.Any(S => S.name.Equals("Body")) || StructureSet.Any(S => S.DicomType.Equals("EXTERNAL")))
                {
                    //Body contour present
                }
                else
                {
                    // missing body contour, which is crucuial to a number of tests
                    nogood = true;
                    MessageBox.Show("The program could not detect a Body contour. This is crucial to a number of tests and neccessary for the Plancheck program to work properly. Please make a Body contour and run the program again.\n\nThe program will now close.");
                    return;
                }

                //System.Windows.Forms.MessageBox.Show(plan.TreatmentOrientation.ToString());

                string PATIENTORIENTATION = null;

                // Head first prone
                if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine)
                {
                    PATIENTORIENTATION = "HeadFirstSupine";
                }
                else if (plan.TreatmentOrientation == PatientOrientation.HeadFirstProne)
                {
                    PATIENTORIENTATION = "HeadFirstProne";
                }
                else if (plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
                {
                    PATIENTORIENTATION = "FeetFirstSupine";
                }
                else if (plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
                {
                    PATIENTORIENTATION = "FeetFirstProne";
                }

                string mlctype = null;
                bool EDW = false;
                double MU = -1.0;
                string MUunit = null;
                string Technique = null;
                string bolusID = null;
                string Linac = null;
                int DoseRate = -1;
                string EnergyMode = null;
                double CouchLongitudinal = -1.0;
                double CouchLateral = -1.0;
                double CouchVertical = -1.0;
                bool ValidDose = false;
                string DoseCalcInfo = null;
                string DoseFieldNormalization = null;
                string DoseHeterogeneityCorrection = null;
                double DoseXsize = -1.0;
                double DoseYsize = -1.0;
                double DoseZsize = -1.0;
                double Zvoxels = -1.0;
                double Zvoxelsize = -1.0;

                if (plan.IsDoseValid == true)
                {
                    ValidDose = true;
                }
                else
                {
                    ValidDose = false;
                }

                DoseXsize = plan.Dose.XRes;
                DoseYsize = plan.Dose.YRes;
                DoseZsize = plan.Dose.ZRes;
                Zvoxels = plan.StructureSet.Image.ZSize;
                Zvoxelsize = plan.StructureSet.Image.ZRes;

                List<PLANCHECK.BEAM> Beams = new List<PLANCHECK.BEAM>();
                foreach (VMS.TPS.Common.Model.API.Beam beam in plan.Beams)
                {
                    if (beam.IsSetupField)
                    {
                        continue;
                    }

                    MU = beam.Meterset.Value;
                    MUunit = beam.Meterset.Unit.ToString();

                    foreach (Wedge w in beam.Wedges)
                    {
                        if (w is EnhancedDynamicWedge)
                        {
                            EDW = true;
                        }
                    }

                    foreach (BeamCalculationLog log in beam.CalculationLogs)
                    {
                        if (log.Category == "Dose")
                        {
                            foreach (string dtr in log.MessageLines)
                            {
                                if (dtr.StartsWith("Information: Service: "))
                                {
                                    DoseCalcInfo = dtr.Substring(21);
                                }
                            }
                        }
                    }

                    PLANCHECK.LMC_CALC_INFO lmcinfo = new PLANCHECK.LMC_CALC_INFO();
                    if (beam.MLCPlanType == MLCPlanType.Static)
                    {
                        mlctype = "Static";
                    }
                    else if (beam.MLCPlanType == MLCPlanType.DoseDynamic)
                    {
                        mlctype = "DoseDynamic";
                    }
                    else if (beam.MLCPlanType == MLCPlanType.ArcDynamic)
                    {
                        mlctype = "ArcDynamic";
                    }
                    else if (beam.MLCPlanType == MLCPlanType.VMAT)
                    {
                        mlctype = "VMAT";
                    }

                    foreach (Bolus bolus in beam.Boluses)
                    {
                        bolusID = bolus.Id;
                    }

                    Technique = beam.Technique.ToString();
                    //MessageBox.Show("Beam Technique: " + Technique);

                    if (Technique == "STATIC" & mlctype == "DoseDynamic")
                    {
                        // IMRT plan. Need to get Calculation logs for LMC efficiency test

                        lmcinfo.ActualMU = beam.Meterset.Value;
                        // MessageBox.Show("Beam " + beam.Id + " MU value: " + lmcinfo.ActualMU);

                        foreach (BeamCalculationLog log in beam.CalculationLogs)
                        {
                            if (log.Category == "LMC")
                            {
                                lmcinfo.MaxMUcr1 = -1;
                                lmcinfo.MaxMUcr2 = -1;
                                lmcinfo.LostMUfactorCR1 = -1;
                                lmcinfo.LostMUfactorCR2 = -1;
                                foreach (string str in log.MessageLines)
                                {
                                    if (str.StartsWith("Information: Maximum MU for carriage group 1"))
                                    {
                                        lmcinfo.MaxMUcr1 = Convert.ToDouble(str.Substring(46));
                                        // MessageBox.Show("Beam " + beam.Id + " Max MU value CR1: " + lmcinfo.MaxMUcr1);
                                    }

                                    if (str.StartsWith("Information: Maximum MU for carriage group 2"))
                                    {
                                        lmcinfo.MaxMUcr2 = Convert.ToDouble(str.Substring(46));
                                        // MessageBox.Show("Beam " + beam.Id + " Max MU value CR2: " + lmcinfo.MaxMUcr2);
                                    }

                                    if (str.StartsWith("Information: Lost MU factor for carriage group 1"))
                                    {
                                        lmcinfo.LostMUfactorCR1 = Convert.ToDouble(str.Substring(50));
                                        //MessageBox.Show("Beam " + beam.Id + " Lost MU factor value CR1: " + lmcinfo.LostMUfactorCR1);
                                    }

                                    if (str.StartsWith("Information: Lost MU factor for carriage group 2"))
                                    {
                                        lmcinfo.LostMUfactorCR2 = Convert.ToDouble(str.Substring(50));
                                        //MessageBox.Show("Beam " + beam.Id + " Lost MU factor value CR2: " + lmcinfo.LostMUfactorCR2);
                                    }
                                }
                            }
                        }
                    }

                    Linac = beam.TreatmentUnit.Id;
                    DoseRate = beam.DoseRate;
                    EnergyMode = beam.EnergyModeDisplayName;
                    CouchLongitudinal = beam.ControlPoints.First().TableTopLongitudinalPosition;
                    CouchLateral = beam.ControlPoints.First().TableTopLateralPosition;
                    CouchVertical = beam.ControlPoints.First().TableTopVerticalPosition;

                    Vector3d iso = new Vector3d(beam.IsocenterPosition.x, beam.IsocenterPosition.y, beam.IsocenterPosition.z);

                    string gantrydir = null;

                    if (beam.GantryDirection == GantryDirection.Clockwise)
                    {
                        gantrydir = "Clockwise";
                    }
                    else if (beam.GantryDirection == GantryDirection.CounterClockwise)
                    {
                        gantrydir = "CounterClockwise";
                    }
                    else if (beam.GantryDirection == GantryDirection.None)
                    {
                        gantrydir = "None";
                    }

                    string beamId = beam.Id;
                    bool setupfield = beam.IsSetupField;
                    double arclength = beam.ArcLength;

                    List<PLANCHECK.CONTROLPOINT> controlpoints = new List<PLANCHECK.CONTROLPOINT>();
                    foreach (ControlPoint cp in beam.ControlPoints)
                    {
                        controlpoints.Add(new PLANCHECK.CONTROLPOINT { Index = cp.Index, Couchangle = cp.PatientSupportAngle, Gantryangle = cp.GantryAngle, CollimatorAngle = cp.CollimatorAngle, MetersetWeight = cp.MetersetWeight, JawPositions = new Tuple<double, double, double, double>(cp.JawPositions.X1, cp.JawPositions.Y1, cp.JawPositions.X2, cp.JawPositions.Y2) });
                    }

                    Beams.Add(new PLANCHECK.BEAM { MLCtype = mlctype, MU = MU, MUunit = MUunit, Technique = Technique, EDWPresent = EDW, LMCinfo = lmcinfo, Linac = Linac, EnergyMode = EnergyMode, CouchLongitudinal = CouchLongitudinal, CouchLateral = CouchLateral, CouchVertical = CouchVertical, DoseRate = DoseRate, BolusId = bolusID, Isocenter = iso, gantrydirection = gantrydir, beamId = beamId, ControlPoints = controlpoints, setupfield = setupfield, arclength = arclength });
                }

                CHPLAN = new PLANCHECK.PLAN { planId = plan.Id, Laterality = laterality , UserName = user, StructureSet = StructureSet, progtype = progtype, ValidDose = ValidDose, ImageZsize = Zvoxels, ImageZRes = Zvoxelsize, DoseGridXSize = DoseXsize, DoseGridYSize = DoseYsize, DoseGridZSize = DoseZsize, DoseCalcInfo = DoseCalcInfo, ApprovalStatus = ApprovalStatus, CreationDateTime = CreationDateTime, CreationUser = CreationUser, DocName = DocName, HospitalName = HospitalName, PatHospitalAddress = HospitalAddress, LastModifiedDateTime = LastModifiedDateTime, LastModifiedUser = LastModifiedUser, PatDOB = PatDOB, PatFirstName = PatFirstName, PatLastName = PatLastName, StructureSetId = plan.StructureSet.Id, TreatmentOrientation = PATIENTORIENTATION, Beams = Beams, PatId = patientId, patientsex = patientsex, courseId = courseId };

                // System.Windows.Forms.MessageBox.Show(Plan.planId + "START body vector conversion");
                //System.Windows.Forms.MessageBox.Show("Body positions size: " + Plan.Body.Positions.Count);
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.ToString() + "\n\n\n" + e.StackTrace + "\n\n\n" + e.InnerException);
            }

            //IMAGE Image = new IMAGE();
            //Image.imageuserorigin = new Vector3d(image.UserOrigin.x, image.UserOrigin.y, image.UserOrigin.z);
            //Image.imageorigin = new Vector3d(image.Origin.x, image.Origin.y, image.Origin.z);

            CHPLAN.progtype = "tiamat";

            //Task.Run(() => System.Windows.Forms.Application.Run(new simpleGUI(pl)));

            //MessageBox.Show("Script done, handoff to PLANCHECK");

            if (nogood == false)
            {
                Task.Run(() => PLANCHECK.PLANCHECK.PLANCHECKEXECUTE(CHPLAN));
            }

            return;
        }


        //==================================================================================================================================================================================================


        public static Task TiamatCollisionCheckExecute(ExternalPlanSetup plan, StructureSet structset, bool SRS, TextBox outbox, string TXsite)
        {
            outbox.AppendText(Environment.NewLine);
            outbox.AppendText("Initiating Fast Collision Check, gathering required plan information...");

            bool couchexist = false;
            bool breastboardexists = false;
            Image image = structset.Image;
            PLAN Plan = new PLAN();

            try
            {
                string patientId = plan.Course.Patient.Id;
                string patientsex = plan.Course.Patient.Sex;
                string courseId = plan.Course.Id;

                // retrieves the body structure
                IEnumerator BR = plan.StructureSet.Structures.GetEnumerator();
                BR.MoveNext();
                BR.MoveNext();
                BR.MoveNext();

                Structure Body = (Structure)BR.Current;

                //Structure CouchSurface = (Structure)BR.Current;

                Structure CouchInterior = (Structure)BR.Current;

                Structure Prone_Brst_Board = (Structure)BR.Current;

                Vector3d bodycenter = new Vector3d();
                Vector3d couchinteriorcenter = new Vector3d();
                Vector3d breastboardcenter = new Vector3d();

                foreach (Structure STR in plan.StructureSet.Structures)
                {
                    if (STR.Id == "Body")
                    {
                        Body = STR;
                        bodycenter = new Vector3d(Body.CenterPoint.x, Body.CenterPoint.y, Body.CenterPoint.z);
                    }
                    else if (STR.Id.Contains("CouchInterior") || STR.Id.Contains("couchinterior") || STR.Id.Contains("couch interior") || STR.Id.Contains("couch_interior") || STR.Id.Contains("Couch_Interior") || STR.Id.Contains("Couch Interior"))
                    {
                        if (STR.IsEmpty == true || STR.Volume < 0.0)
                        {
                            System.Windows.Forms.MessageBox.Show("The Couch Interior structure is not contoured!");
                            continue;
                        }

                        // System.Windows.Forms.MessageBox.Show("Found couch interior");
                        couchexist = true;
                        CouchInterior = STR;
                        couchinteriorcenter = new Vector3d(CouchInterior.CenterPoint.x, CouchInterior.CenterPoint.y, CouchInterior.CenterPoint.z);
                    }
                    else if (STR.Id.Contains("Prone_Brst_Board") || STR.Id.Contains("NS_Prone_Bst_Brd") || STR.Id.Contains("Prone_Bst_Brd") || STR.Id.Contains("Prone_Brst_Brd") || STR.Id.Contains("Prone_Bst_Board") || STR.Id.Contains("Prone Brst Board") || STR.Id.Contains("Prone Bst Brd") || STR.Id.Contains("Prone Brst Brd") || STR.Id.Contains("Prone Bst Board") || STR.Id.Contains("prone_brst_board") || STR.Id.Contains("prone_bst_brd") || STR.Id.Contains("prone_brst_brd") || STR.Id.Contains("prone_bst_board") || STR.Id.Contains("prone brst board") || STR.Id.Contains("prone bst brd") || STR.Id.Contains("pron brst brd") || STR.Id.Contains("prone bst board"))
                    {
                        if (STR.IsEmpty == true || STR.Volume < 0.0)
                        {
                            System.Windows.Forms.MessageBox.Show("The Prone Breast Board structure is not contoured!");
                            continue;
                        }

                        // System.Windows.Forms.MessageBox.Show("Found breast board");
                        Prone_Brst_Board = STR;
                        breastboardexists = true;
                        breastboardcenter = new Vector3d(Prone_Brst_Board.CenterPoint.x, Prone_Brst_Board.CenterPoint.y, Prone_Brst_Board.CenterPoint.z);
                    }

                    //else if (STR.Id == "CouchSurface" || )
                    //{
                    //    CouchSurface = STR;
                    //    findCouchSurf = true;
                    //}

                    // findCouchSurf = false;

                }

                //System.Windows.Forms.MessageBox.Show(plan.TreatmentOrientation.ToString());

                string PATIENTORIENTATION = null;

                // Head first prone
                if (plan.TreatmentOrientation == PatientOrientation.HeadFirstSupine)
                {
                    PATIENTORIENTATION = "HeadFirstSupine";
                }
                else if (plan.TreatmentOrientation == PatientOrientation.HeadFirstProne)
                {
                    PATIENTORIENTATION = "HeadFirstProne";
                }
                else if (plan.TreatmentOrientation == PatientOrientation.FeetFirstSupine)
                {
                    PATIENTORIENTATION = "FeetFirstSupine";
                }
                else if (plan.TreatmentOrientation == PatientOrientation.FeetFirstProne)
                {
                    PATIENTORIENTATION = "FeetFirstProne";
                }

                List<BEAM> Beams = new List<BEAM>();
                foreach (Beam beam in plan.Beams)
                {
                    string mlctype = null;

                    if (beam.MLCPlanType == MLCPlanType.Static)
                    {
                        mlctype = "Static";
                    }
                    else
                    {
                        mlctype = "Not Static";
                    }

                    Vector3d iso = new Vector3d(beam.IsocenterPosition.x, beam.IsocenterPosition.y, beam.IsocenterPosition.z);
                    VVector st = new VVector();
                    Vector3d apiSource = new Vector3d();    // only for use with non-isocentric beams
                    string gantrydir = null;

                    if (beam.GantryDirection == GantryDirection.Clockwise)
                    {
                        gantrydir = "Clockwise";
                    }
                    else if (beam.GantryDirection == GantryDirection.CounterClockwise)
                    {
                        gantrydir = "CounterClockwise";
                    }
                    else if (beam.GantryDirection == GantryDirection.None)
                    {
                        gantrydir = "None";
                        // meaning not an arc
                        st = beam.GetSourceLocation(beam.ControlPoints.First().GantryAngle);
                        //System.Windows.Forms.MessageBox.Show("st : (" + st.x + ", " + st.y + ", " + st.z + ")");
                    }

                    string beamId = beam.Id;
                    bool setupfield = beam.IsSetupField;
                    double arclength = beam.ArcLength;
                    apiSource = new Vector3d(st.x, st.y, st.z);

                    List<CONTROLPOINT> controlpoints = new List<CONTROLPOINT>();
                    foreach (ControlPoint cp in beam.ControlPoints)
                    {
                        //System.Windows.Forms.MessageBox.Show("Gantryangle: " + cp.GantryAngle);
                        controlpoints.Add(new CONTROLPOINT { Couchangle = cp.PatientSupportAngle, Gantryangle = cp.GantryAngle });
                    }
                    //System.Windows.Forms.MessageBox.Show("controlpoints size: " + controlpoints.Count);
                    //System.Windows.Forms.MessageBox.Show("APISource : (" + apiSource.x + ", " + apiSource.y + ", " + apiSource.z + ")");
                    Beams.Add(new BEAM { MLCtype = mlctype, Isocenter = iso, APISource = apiSource, gantrydirection = gantrydir, beamId = beamId, ControlPoints = controlpoints, setupfield = setupfield, arclength = arclength });
                }

                Plan = new PLAN { planId = plan.Id, StructureSetId = plan.StructureSet.Id, TreatmentOrientation = PATIENTORIENTATION, Body = Body.MeshGeometry, CouchInterior = CouchInterior.MeshGeometry, ProneBreastBoard = Prone_Brst_Board.MeshGeometry, breastboardexists = breastboardexists, couchexists = couchexist, Beams = Beams, patientId = patientId, patientsex = patientsex, courseId = courseId, Bodycenter = bodycenter, BreastBoardcenter = breastboardcenter, CouchInteriorcenter = couchinteriorcenter, Bodyvects = new List<Vector3d>(), Bodyindices = new List<int>(), CouchInteriorvects = new List<Vector3d>(), CouchInteriorindices = new List<int>(), BreastBoardvects = new List<Vector3d>(), BreastBoardindices = new List<int>(), BodyBoxXsize = 1000000.0, BodyBoxYSize = 1000000.0, BodyBoxZSize = 1000000.0 };

                // System.Windows.Forms.MessageBox.Show(Plan.planId + "START body vector conversion");
                //System.Windows.Forms.MessageBox.Show("Body positions size: " + Plan.Body.Positions.Count);

                foreach (Point3D p in Plan.Body.Positions)
                {
                    double XP = p.X;
                    double YP = p.Y;
                    double ZP = p.Z;
                    Vector3d Vect = new Vector3d(XP, YP, ZP);
                    Plan.Bodyvects.Add(Vect);
                }

                foreach (int t in Plan.Body.TriangleIndices)
                {
                    Plan.Bodyindices.Add(t);
                }

                if (Plan.couchexists == true)
                {
                    // System.Windows.Forms.MessageBox.Show("couch vector conversion");
                    foreach (Point3D p in Plan.CouchInterior.Positions)
                    {
                        Plan.CouchInteriorvects.Add(new g3.Vector3d { x = p.X, y = p.Y, z = p.Z });
                    }

                    foreach (int t in Plan.CouchInterior.TriangleIndices)
                    {
                        Plan.CouchInteriorindices.Add(t);
                    }
                }

                if (Plan.breastboardexists == true)
                {
                    // System.Windows.Forms.MessageBox.Show("breast board vector conversion");
                    foreach (Point3D p in Plan.ProneBreastBoard.Positions)
                    {
                        Plan.BreastBoardvects.Add(new g3.Vector3d { x = p.X, y = p.Y, z = p.Z });
                    }

                    foreach (int t in Plan.ProneBreastBoard.TriangleIndices)
                    {
                        Plan.BreastBoardindices.Add(t);
                    }
                }

                Plan.BodyBoxXsize = Plan.Body.Bounds.SizeX;
                Plan.BodyBoxYSize = Plan.Body.Bounds.SizeY;
                Plan.BodyBoxZSize = Plan.Body.Bounds.SizeZ;

            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.ToString() + "\n\n\n" + e.StackTrace + "\n\n\n" + e.InnerException);
            }

            IMAGE Image = new IMAGE();
            Image.imageuserorigin = new Vector3d(image.UserOrigin.x, image.UserOrigin.y, image.UserOrigin.z);
            Image.imageorigin = new Vector3d(image.Origin.x, image.Origin.y, image.Origin.z);

            outbox.AppendText(Environment.NewLine);
            outbox.AppendText("Starting Collision Check analysis on separate process..");

            System.Windows.Forms.Application.EnableVisualStyles();
            
            Task internalcollisioncheck = Task.Run(() => System.Windows.Forms.Application.Run(new TiamatCollisionCheckGUI(Plan, Image, SRS, TXsite)));

            return internalcollisioncheck;
            //outbox.AppendText(Environment.NewLine);
            //outbox.AppendText("**Collision Check Launched**");
        }

    }

    //==================================================================================================================================================================================

    class OptimizationObjective
    {
        public string StructureID { get; set; }

        public DoseValue DoseValue { get; set; }

        public double Priority { get; set; }

        public OptimizationObjectiveOperator ObjectiveOperator { get; set; }

        //this number is volume as a percentage
        public double Volume { get; set; }

        //For internal use
        public string ObjectiveType { get; set; }

    }







}
