using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Forms;

using CollisionCheck;

namespace Tiamat
{
    public partial class TiamatCollisionCheckGUI : Form
    {
        public TiamatCollisionCheckGUI(PLAN Plan, IMAGE image, bool SRS, string TXsite)
        {
            InitializeComponent();

            TCout.AppendText("Processing information for Fast Collision Check Analysis...");

            TCprogbar.Style = ProgressBarStyle.Marquee;
            TCprogbar.MarqueeAnimationSpeed = 100;
            Show();
            //basically a replacemnt for all of the code-behind in the GUI in the traditional CollisionCheck Program

            bool FAST = true;
            string Acc = null;
            string bodyloc = null;
            string height = null;

            if(SRS == true)
            {
                Acc = "SRS Cone";
            }

            //TCout.AppendText("\n\nProcessing information for Collision Check...");

            //  MessageBox.Show("pl is: " + pl);

            switch (TXsite)
            {
                case "Abdomen":
                    bodyloc = "Abdomen";
                    break;

                case "Brain":
                    bodyloc = "Head";
                    break;

                case "Breast":
                    bodyloc = "Abdomen";
                    break;

                case "Esophagus":
                    bodyloc = "Thorax";
                    break;

                case "Gynecological":
                    bodyloc = "Pelvis";
                    break;

                case "Head & Neck":
                    bodyloc = "Thorax";
                    break;

                case "Lung":
                    bodyloc = "Abdomen";
                    break;

                case "Pelvis":
                    bodyloc = "Pelvis";
                    break;

                case "Prostate":
                    bodyloc = "Pelvis";
                    break;

                case "Prostate Bed":
                    bodyloc = "Pelvis";
                    break;

                case "Thorax (Other)":
                    bodyloc = "Thorax";
                    break;

                case "SBRT Liver":
                    bodyloc = "Abdomen";
                    break;

                case "SRS Cranial AVM":
                    bodyloc = "Head";
                    break;

                case "SRS Cranial Trigeminal Neuralgia":
                    bodyloc = "Head";
                    break;
            }

            if (Plan.patientsex == "Female")
            {
                height = "161.5";

            }
            else if (Plan.patientsex == "Male")
            {
                height = "175.4";
            }
            else
            {
                height = "167.5";
            }

            List<BEAM> BEAMLIST = new List<BEAM>();

            try
            {
                double ht = Convert.ToDouble(height);
                //List<BEAM> BEAMLIST = new List<BEAM>();
                foreach (BEAM be in Plan.Beams)
                {
                    if (Plan.couchexists == false & Plan.breastboardexists == false)
                    {
                        BEAMLIST.Add(new BEAM
                        {
                            gantrydirection = be.gantrydirection,
                            setupfield = be.setupfield,
                            Isocenter = be.Isocenter,
                            MLCtype = be.MLCtype,
                            beamId = be.beamId,
                            arclength = be.arclength,
                            ControlPoints = be.ControlPoints,
                            imageuserorigin = image.imageuserorigin,
                            imageorigin = image.imageorigin,
                            APISource = be.APISource,
                            planId = Plan.planId,
                            patientId = Plan.patientId,
                            courseId = Plan.courseId,
                            patientsex = Plan.patientsex,
                            StructureSetId = Plan.StructureSetId,
                            TreatmentOrientation = Plan.TreatmentOrientation,
                            Bodycenter = Plan.Bodycenter,
                            CouchInteriorcenter = Plan.CouchInteriorcenter,
                            BreastBoardcenter = Plan.BreastBoardcenter,
                            couchexists = Plan.couchexists,
                            breastboardexists = Plan.breastboardexists,
                            bodylocation = bodyloc,
                            patientheight = ht,

                            //CUSTOM MADE MESH INFO

                            BodyBoxXsize = Plan.BodyBoxXsize,
                            BodyBoxYSize = Plan.BodyBoxYSize,
                            BodyBoxZSize = Plan.BodyBoxZSize,
                            Bodyvects = Plan.Bodyvects,
                            Bodyindices = Plan.Bodyindices
                        });
                    }
                    else if (Plan.couchexists == true & Plan.breastboardexists == false)
                    {
                        BEAMLIST.Add(new BEAM
                        {
                            gantrydirection = be.gantrydirection,
                            setupfield = be.setupfield,
                            Isocenter = be.Isocenter,
                            MLCtype = be.MLCtype,
                            beamId = be.beamId,
                            arclength = be.arclength,
                            ControlPoints = be.ControlPoints,
                            imageuserorigin = image.imageuserorigin,
                            imageorigin = image.imageorigin,
                            APISource = be.APISource,
                            planId = Plan.planId,
                            patientId = Plan.patientId,
                            courseId = Plan.courseId,
                            patientsex = Plan.patientsex,
                            StructureSetId = Plan.StructureSetId,
                            TreatmentOrientation = Plan.TreatmentOrientation,
                            Bodycenter = Plan.Bodycenter,
                            CouchInteriorcenter = Plan.CouchInteriorcenter,
                            BreastBoardcenter = Plan.BreastBoardcenter,
                            couchexists = Plan.couchexists,
                            breastboardexists = Plan.breastboardexists,
                            bodylocation = bodyloc,
                            patientheight = ht,

                            //CUSTOM MADE MESH INFO

                            BodyBoxXsize = Plan.BodyBoxXsize,
                            BodyBoxYSize = Plan.BodyBoxYSize,
                            BodyBoxZSize = Plan.BodyBoxZSize,
                            Bodyvects = Plan.Bodyvects,
                            Bodyindices = Plan.Bodyindices,
                            CouchInteriorvects = Plan.CouchInteriorvects,
                            CouchInteriorindices = Plan.CouchInteriorindices
                        });
                    }
                    else if (Plan.couchexists == false & Plan.breastboardexists == true)
                    {
                        BEAMLIST.Add(new BEAM
                        {
                            gantrydirection = be.gantrydirection,
                            setupfield = be.setupfield,
                            Isocenter = be.Isocenter,
                            MLCtype = be.MLCtype,
                            beamId = be.beamId,
                            arclength = be.arclength,
                            ControlPoints = be.ControlPoints,
                            imageuserorigin = image.imageuserorigin,
                            imageorigin = image.imageorigin,
                            APISource = be.APISource,
                            planId = Plan.planId,
                            patientId = Plan.patientId,
                            courseId = Plan.courseId,
                            patientsex = Plan.patientsex,
                            StructureSetId = Plan.StructureSetId,
                            TreatmentOrientation = Plan.TreatmentOrientation,
                            Bodycenter = Plan.Bodycenter,
                            CouchInteriorcenter = Plan.CouchInteriorcenter,
                            BreastBoardcenter = Plan.BreastBoardcenter,
                            couchexists = Plan.couchexists,
                            breastboardexists = Plan.breastboardexists,
                            bodylocation = bodyloc,
                            patientheight = ht,

                            //CUSTOM MADE MESH INFO

                            BodyBoxXsize = Plan.BodyBoxXsize,
                            BodyBoxYSize = Plan.BodyBoxYSize,
                            BodyBoxZSize = Plan.BodyBoxZSize,
                            Bodyvects = Plan.Bodyvects,
                            Bodyindices = Plan.Bodyindices,
                            BreastBoardvects = Plan.BreastBoardvects,
                            BreastBoardindices = Plan.BreastBoardindices
                        });
                    }
                    else if (Plan.couchexists == true & Plan.breastboardexists == true)
                    {
                        BEAMLIST.Add(new BEAM
                        {
                            gantrydirection = be.gantrydirection,
                            setupfield = be.setupfield,
                            Isocenter = be.Isocenter,
                            MLCtype = be.MLCtype,
                            beamId = be.beamId,
                            arclength = be.arclength,
                            ControlPoints = be.ControlPoints,
                            imageuserorigin = image.imageuserorigin,
                            imageorigin = image.imageorigin,
                            APISource = be.APISource,
                            planId = Plan.planId,
                            patientId = Plan.patientId,
                            courseId = Plan.courseId,
                            patientsex = Plan.patientsex,
                            StructureSetId = Plan.StructureSetId,
                            TreatmentOrientation = Plan.TreatmentOrientation,
                            Bodycenter = Plan.Bodycenter,
                            CouchInteriorcenter = Plan.CouchInteriorcenter,
                            BreastBoardcenter = Plan.BreastBoardcenter,
                            couchexists = Plan.couchexists,
                            breastboardexists = Plan.breastboardexists,
                            bodylocation = bodyloc,
                            patientheight = ht,

                            //CUSTOM MADE MESH INFO

                            BodyBoxXsize = Plan.BodyBoxXsize,
                            BodyBoxYSize = Plan.BodyBoxYSize,
                            BodyBoxZSize = Plan.BodyBoxZSize,
                            Bodyvects = Plan.Bodyvects,
                            Bodyindices = Plan.Bodyindices,
                            BreastBoardvects = Plan.BreastBoardvects,
                            BreastBoardindices = Plan.BreastBoardindices,
                            CouchInteriorvects = Plan.CouchInteriorvects,
                            CouchInteriorindices = Plan.CouchInteriorindices
                        });
                    }
                }

                BEAMLIST.RemoveAll(el => el.setupfield == true);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            TCout.AppendText(Environment.NewLine);
            TCout.AppendText("\n\nStarting CollisionCheck Analysis...");
            BEAMLIST.RemoveAll(k => k.MLCtype == "Static");

            List<CollisionAlert> output = CollisionCheckMethods.CollisionCheckExecute(BEAMLIST, TCout, Acc, FAST);

            TCprogbar.Visible = false;
            Refresh();

            if (output.Count == 0)
            {
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText("Collision analysis complete. No collisions detected.");
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText("Although no collisions were detected, the program will render images of its model for each beam for you to view if you wish.");
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText("A separate window depicting an image of the 3D collision model will now open for each beam. You can click and drag your mouse (slowly) to rotate the image and use the mouse wheel to zoom in and out.");
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText("This window will persist until closed.");
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText("You can close the window or run the program again.");

                CollOutput.AppendText(Environment.NewLine);
                CollOutput.AppendText("No Collisions found.");
                CollOutput.AppendText(Environment.NewLine);

                Refresh();
                MessageBox.Show("No Collisions detected!");
            }
            else
            {
                // special dialog box in case of found collision with a red background and such for effect
                string status = "WARNING: COLLISIONS/TIGHT CLEARANCE DETECTED!";

                OutputWindow(status);

                TCout.AppendText(Environment.NewLine);
                TCout.AppendText("Collision analysis complete. Collisions/tight clearance detected!");
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText("Rendering Collision images...");
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText("A separate window depicting an image of the 3D collision model will now open for each beam. You can click and drag your mouse (slowly) to rotate the image and use the mouse wheel to zoom in and out.");
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText("This window will persist until closed.");
                TCout.AppendText(Environment.NewLine);
                TCout.AppendText("You can close the window or run the program again.");

                CollOutput.AppendText(Environment.NewLine);
                CollOutput.AppendText("The following collisions are predicted...");
                CollOutput.AppendText(Environment.NewLine);
                CollOutput.AppendText(Environment.NewLine);
                Refresh();
            }
 
            if (output.Count > 0)
            {
                // Patient Point: (" + Math.Round(alert.Patpoint.x, 1, MidpointRounding.AwayFromZero) + ", " + Math.Round(alert.Gantrypoint.y, 1, MidpointRounding.AwayFromZero) + ", " + Math.Round(alert.Gantrypoint.z, 1, MidpointRounding.AwayFromZero) + ")
                // last contig should be false by default in the collision alert class
                foreach (CollisionAlert alert in output)
                {
                    if (output.First().PatObject.StartsWith("FAST"))
                    {
                        CollOutput.AppendText(Environment.NewLine);
                        CollOutput.AppendText(Environment.NewLine);
                        CollOutput.AppendText("Beam " + alert.beam + ": Collision/tight clearance between " + alert.GantryObject + " and " + alert.PatObject + "." + Environment.NewLine + "Gantry Angle: " + alert.gantryangle + "  Couch Angle: " + alert.couchangle + "  Rotation Direction: " + alert.rotationdirection);
                        CollOutput.AppendText(Environment.NewLine);
                    }
                    else
                    {
                        if (alert.contiguous == true)
                        {
                            continue;
                        }

                        if (alert.endoflist == true)
                        {
                            CollOutput.AppendText(Environment.NewLine);
                            CollOutput.AppendText(Environment.NewLine);
                            CollOutput.AppendText("END OF BEAM " + alert.beam + ". " + alert.GantryObject + " still in potential collision area with " + alert.PatObject + "." + Environment.NewLine + "Couch Angle: " + alert.couchangle + "  Gantry Angle: " + alert.gantryangle + "  Rotation Direction: " + alert.rotationdirection + "  Distance: " + alert.distance + " mm");
                            CollOutput.AppendText(Environment.NewLine);
                        }
                        else
                        {
                            if (alert.lastcontig == false)
                            {
                                CollOutput.AppendText(Environment.NewLine);
                                CollOutput.AppendText(Environment.NewLine);
                                CollOutput.AppendText("Beam " + alert.beam + ": START of " + alert.GantryObject + " potential collision area with " + alert.PatObject + "." + Environment.NewLine + "Couch Angle: " + alert.couchangle + "  Gantry Angle: " + alert.gantryangle + "  Rotation Direction: " + alert.rotationdirection + "  Distance: " + alert.distance + " mm");
                                CollOutput.AppendText(Environment.NewLine);
                            }
                            else if (alert.lastcontig == true)
                            {
                                CollOutput.AppendText(Environment.NewLine);
                                CollOutput.AppendText(Environment.NewLine);
                                CollOutput.AppendText("Beam " + alert.beam + ": END of " + alert.GantryObject + " potential collision area with " + alert.PatObject + "." + Environment.NewLine + "Couch Angle: " + alert.couchangle + "  Gantry Angle: " + alert.gantryangle + "  Rotation Direction: " + alert.rotationdirection + "  Distance: " + alert.distance + " mm");
                                CollOutput.AppendText(Environment.NewLine);
                            }
                        }
                    } // ends if FAST mode or not
                }
            }

            Thread.Sleep(1000); //wait 1 seconds

            foreach (BEAM Be in BEAMLIST)
            {
                FileInfo file = new FileInfo(@"\\ntfs16\Therapyphysics\Treatment Planning Systems\Eclipse\Scripting common files\Collision_Check_STL_files\" + Plan.patientId + "_" + Plan.courseId + "_" + Plan.planId + "_" + "Beam_" + Be.beamId + ".stl"); //Lahey                                                                                                                                                                                                                                // FileInfo file = new FileInfo(@"\\shceclipseimg\PHYSICS\New File Structure PHYSICS\Script Reports\Collision_Check_STL_files\" + Plan.patientId + "_" + Plan.courseId + "_" + Plan.planId + "_" + "Beam_" + al.beam + ".stl"); //Winchester
                bool ftest = IsFileLocked(file, Be.beamId);
                if (ftest == false)
                {
                    string window_init = @"\\ntfs16\Therapyphysics\Treatment Planning Systems\Eclipse\Scripting common files\Collision_Check_STL_files\" + Plan.patientId + "_" + Plan.courseId + "_" + Plan.planId + "_" + "Beam_" + Be.beamId + ".stl"; //Lahey
                                                                                                                                                                                                                                                          // string window_init = @"\\shceclipseimg\PHYSICS\New File Structure PHYSICS\Script Reports\Collision_Check_STL_files\" + Plan.patientId + "_" + Plan.courseId + "_" + Plan.planId + "_" + "Beam_" + al.beam + ".stl";  //Winchester
                    Thread WPFWindowInit = new Thread(() =>
                    {
                        _3DRender.MainWindow window = new _3DRender.MainWindow(window_init, Be.beamId);
                        window.Closed += (s, e) =>
                            Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
                        window.Show();
                        Dispatcher.Run();
                    });

                    WPFWindowInit.SetApartmentState(ApartmentState.STA);
                    WPFWindowInit.Start();
                }
            }

        }

        protected static bool IsFileLocked(FileInfo file, string beamid)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException e)
            {
                System.Windows.Forms.MessageBox.Show("An IOException occured when attempting to open the image file for the beam " + beamid + "." + Environment.NewLine + " This file is either 1) Still being written to. 2) Being processed by another thread. 3) Does not exist. The program will skip opening the image file." + Environment.NewLine + " The following information is just to help Zack debug this. You can close the dialog box without a problem." + Environment.NewLine + Environment.NewLine + "Source:   " + e.Source + Environment.NewLine + "Message:   " + e.Message + Environment.NewLine + "Stack Trace:   " + e.StackTrace);

                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }


        public static DialogResult OutputWindow(string status)
        {
            Form Dialog = new Form()
            {
                Width = 400,
                Height = 400,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Collision Status",
                BackColor = Color.Red,
                StartPosition = FormStartPosition.CenterScreen,
                Font = new System.Drawing.Font("Goudy Old Style", 16.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))
            };
            Label txtlab = new Label() { Left = 10, Top = 15, Width = 320, Height = 140, Text = status };
            Button confirm = new Button() { Text = "Ok", Left = 120, Width = 100, Top = 300, DialogResult = DialogResult.OK };

            confirm.Click += (sender, e) => { Dialog.Close(); };
            Dialog.Controls.Add(confirm);
            Dialog.Controls.Add(txtlab);
            Dialog.AcceptButton = confirm;

            return Dialog.ShowDialog();
        }






    }
}
