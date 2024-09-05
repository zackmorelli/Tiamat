using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;

namespace Tiamat
{
    public partial class InitialTiamatGUI : Form
    {
      
        public InitialTiamatGUI(Patient patient, Course course, StructureSet structureset, ExternalPlanSetup plan, User user)
        {
            // this is an awaitable task that is called
            // need to return a list of strings that has all the info we need
            string[] UI = new string[13];
            InitializeComponent();
            BootPanel.BringToFront();

            //need to set default values for some of the drop downs
            //This is for the case where the user is only using the program to generate a QA plan or make imaging beams
            //They don't need to select a treatment techinique or laterality, so we pre-select "NA"
            //For any treatment site other than "NA" that the user selects, the treatment technique and laterality will dynamically change
            //The user at least always needs to select a linac!

            TreatSiteBox.SelectedItem = "NA";
            TreatTechBox.SelectedItem = "NA";
            LateralityBox.SelectedItem = "NA";

            ExBut.Click += (sender, EventArgs) => { LAMBDALINK(sender, EventArgs, UI, patient, course, structureset, plan, user); };
            // EXECUTE collects all the required info and puts it into the string list UI, which should be available to the main program.
            // LAMDALINK then calls the Close method of this Form, which should close the GUI window without ending the entire program
            // This Close method should raise an event on the main program that it can start execution using the string list that actually has info in it now.
        }


        private void EXECUTE(string[] UI)
        {
            // collect all information, put in UI

            // UI O - Linac
            // UI 1 - Treatment Technique
            // UI 2 - Treatment Site
            // UI 3 - Laterality
            // UI 4 - SetupBeams
            // UI 5 - Optimize
            // UI 6 - Rapidplan
            // UI 7 - DoseCalc
            // UI 8 - Acuros Algo
            // UI 9 - Trade-off analysis
            // UI 10 - QA plan
            // UI 11 - Optimization Objective Set

            UI[0] = (string)LinacBox.SelectedItem;
            UI[1] = (string)TreatTechBox.SelectedItem;
            UI[2] = (string)TreatSiteBox.SelectedItem;
            UI[3] = (string)LateralityBox.SelectedItem;

            if (OptObjBox.Items.Count == 0)
            {
                UI[11] = "NA";
            }
            else if (OptObjBox.Items.Count > 0)
            {
                UI[11] = OptObjBox.SelectedItem.ToString();
            }

            if(SetupBeamsCBox.Checked == true)
            {
                UI[4] = "SetupBeams - Y";
            }
            else
            {
                UI[4] = "SetupBeams - N";
            }

            if(OptimizeCBox.Checked)
            {
                UI[5] = "Optimize - Y";
            }
            else
            {
                UI[5] = "Optimize - N";
            }

            if (RapidCBox.Visible == true)
            {
                if(RapidCBox.Checked)
                {
                    UI[6] = "Rapid - Y";
                }
                else
                {
                    UI[6] = "Rapid - N";
                }
            }
            else
            {
                UI[6] = ("Rapid - NA");
            }

            if (DoseCalcCBox.Checked)
            {
                UI[7] = "DoseCalc - Y";
            }
            else
            {
                UI[7] = "DoseCalc - N";
            }

            if(AlgoCBox.Visible == true)
            {
                if(AlgoCBox.Checked)
                {
                    UI[8] = "Acuros - Y";
                }
                else
                {
                    UI[8] = "Acuros - N";
                }
            }
            else
            {
                UI[8] = "Acuros - NA";
            }

            if(TradeOffCBox.Checked)
            {
                UI[9] = "Tradeoff - Y";
            }
            else
            {
                UI[9] = "Tradeoff - N";
            }
        }

        private void OptimizeCheckChange(object sender, EventArgs args)
        {
            if (OptimizeCBox.Checked == true)
            {
                RapidCBox.Visible = true;

                if(TreatSiteBox.SelectedItem.ToString() == "Head & Neck")
                {
                    OptObjLabel.Visible = true;
                    OptObjBox.Visible = true;

                    OptObjBox.Items.AddRange(new object[]
                    {
                        "H&N 7000 cGy",
                        "H&N 6996 cGy",
                        "H&N 6600 cGy"
                    });
                }

                if (TreatSiteBox.SelectedItem.ToString() == "Lung")
                {
                    OptObjLabel.Visible = true;
                    OptObjBox.Visible = true;

                    OptObjBox.Items.AddRange(new object[]
                    {
                        "Lung SBRT 4fx",
                        "Lung SBRT 5fx",
                        "Lung SBRT 8fx"
                    });
                }


                // we'll need something for prostate
                //if (TreatSiteBox.SelectedItem.ToString() == "Prostate")
                //{
                //    OptObjLabel.Visible = true;
                //    OptObjBox.Visible = true;

                //    OptObjBox.Items.AddRange(new object[]
                //    {
                //        "H&N 7000 cGy",
                //        "H&N 6996 cGy",
                //        "H&N 6600 cGy"
                //    });
                //}
















            }
            else
            {
                RapidCBox.Visible = false;
                OptObjLabel.Visible = false;
                OptObjBox.Visible = false;
                OptObjBox.Items.Clear();
            }
        }

        private void DoseCheckChange(object sender, EventArgs args)
        {
            if (DoseCalcCBox.Checked == true)
            {
                AlgoCBox.Visible = true;
            }
            else
            {
                AlgoCBox.Visible = false;
            }
        }

        private void TreatSiteSelect(object sender, EventArgs args)
        {
            string sel = Convert.ToString(TreatSiteBox.SelectedItem);
            switch (sel)
            {
                case "NA":
                    LateralityBox.Items.AddRange(new object[]
                    {
                        "NA"
                    });
                    LateralityBox.SelectedItem = "NA";

                    TreatTechBox.Items.Clear();
                    TreatTechBox.Items.AddRange(new object[]
                    {
                        "NA",
                    });
                    TreatTechBox.SelectedItem = "NA";

                    break;

                case "Abdomen":
                    LateralityBox.Items.Clear();
                    LateralityBox.Items.AddRange(new object[]
                    {
                        "NA"
                    });
                    LateralityBox.SelectedItem = "NA";

                    TreatTechBox.Items.Clear();
                    TreatTechBox.Items.AddRange(new object[]
                    {
                        "9-field static",
                        "2-Arc VMAT",
                    });

                    break;

                case "Brain":

                    break;

                case "Breast":

                    break;

                case "Esophagus":

                    break;

                case "Gynecological":

                    break;

                case "Head & Neck":
                    LateralityBox.Items.Clear();
                    LateralityBox.Items.AddRange(new object[]
                    {
                        "Right",
                        "Left",
                        "Bilateral"
                    });

                    TreatTechBox.Items.Clear();
                    TreatTechBox.Items.AddRange(new object[]
                    {
                        "3-Arc VMAT"
                    });
                    break;

                case "Lung":
                    LateralityBox.Items.Clear();
                    LateralityBox.Items.AddRange(new object[]
                    {
                        "Right",
                        "Left",
                    });

                    TreatTechBox.Items.Clear();
                    TreatTechBox.Items.AddRange(new object[]
                    {
                        "2-Arc VMAT",
                        "7-field Static"
                    });
                    break;

                    //"Pelvis",
                    //"Prostate",
                    //"Prostate Bed",
                    //"Thorax (Other)",
                    //"SBRT Liver",
                    //"SRS Cranial AVM",
                    //"SRS Cranial Trigeminal Neuralgia"
            }
        }

        void LAMBDALINK(object sender, EventArgs e, string[] UI, Patient patient, Course course, StructureSet structureset, ExternalPlanSetup plan, User user)
        {

            if (LinacBox.SelectedItem == null)
            {
                MessageBox.Show("At the very least, a Linac must be selected!");
                return;
            }

            try
            {
                EXECUTE(UI);

                BootPanel.Visible = false;
                RunningPanel.Visible = true;
                RunningPanel.BringToFront();
                RunningPanel.Refresh();

                OutBox.AppendText("Program Starting.");
                TiamatEx.TiamatExecute(UI, patient, course, structureset, plan, user, OutBox, ProgBar);

                RunningPanel.Visible = false;
                BootPanel.Visible = true;
                BootPanel.BringToFront();
                RunningPanel.Refresh();
                MessageBox.Show("Program finished.");

            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.ToString());
                MessageBox.Show("Overall Tiamat Execute error: \n" + ae.ToString() + "\n" + ae.StackTrace + "\n" + ae.InnerException + "\n" + ae.TargetSite + "\n" + ae.Source);
            }
        }


    }
}
