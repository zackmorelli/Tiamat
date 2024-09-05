using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media.Media3D;
using g3;

namespace PLANCHECK
{
    public class MiscPlanCheckUtilities
    {
        public static async Task<StreamReader> GantryRetrievalAsync(string PATid, string COURSEid, string PLANid, BEAM beam)
        {
            StreamReader GantryAngleRetrieveOutput = await Task.Run(() => ActualRetrieval(PATid, COURSEid, PLANid, beam));
            return GantryAngleRetrieveOutput;
        }

        public static StreamReader ActualRetrieval(string PATid, string COURSEid, string PLANid, BEAM beam)
        {
            string planID = "\"" + PLANid + "\"";
            ProcessStartInfo processinfo = new ProcessStartInfo(@"\\wvvrnimbp01ss\va_data$\filedata\ProgramData\Vision\Stand-alone Programs\CollisionCheck_InfoRetrieval\CollisionCheck_InfoRetrieval.exe", PATid + " ," + COURSEid + " ," + planID + " ," + beam.beamId);        // path name of the Collision retrieval program

            processinfo.UseShellExecute = false;
            processinfo.ErrorDialog = false;
            processinfo.RedirectStandardOutput = true;
            processinfo.WindowStyle = ProcessWindowStyle.Hidden;

            Process GantryAngleRetrieve = new Process();
            GantryAngleRetrieve.StartInfo = processinfo;
            GantryAngleRetrieve.EnableRaisingEvents = true;

            GantryAngleRetrieve.Start();
            StreamReader Gstream = GantryAngleRetrieve.StandardOutput;
            GantryAngleRetrieve.WaitForExit();
            return Gstream;
        }










    }

    public class ReportData
    {
        public string PatId { get; set; }

        public string PatFirstName { get; set; }

        public string PatLastName { get; set; }

        public DateTime? PatDOB { get; set; }

        public string PatSex { get; set; }

        public string DocName { get; set; }

        public string UserName { get; set; }

        public string PatHospitalName { get; set; } 

        public string PatHospitalAddress { get; set; }

        public string CourseId { get; set; } 

        public string PlanId { get; set; }

        public string ApprovalStatus { get; set; }
             
        public DateTime? CreationDateTime { get; set; } 

        public string CreationUser { get; set; }

        public DateTime LastModifiedDateTime { get; set; }

        public string LastModifiedUser { get; set; } 

        public string TreatmentSite { get; set; } 

        public List<PLANCHECKRESULTS> CheckResults { get; set; }
    }

    public class PLANCHECKRESULTS
    {
        public string Name { get; set; }

        public string status { get; set; }

        // a comment or explanation of what went wrong, if neccesary
        public string comment { get; set; }
    }


    public class PLAN
    {
        public string planId { get; set; }

        public string PatId { get; set; }

        public string courseId { get; set; }

        public string PatFirstName { get; set; }

        public string PatLastName { get; set; }

        public DateTime? PatDOB { get; set; }

        public string DocName { get; set; }

        public string UserName { get; set; }

        public string HospitalName { get; set; }

        public string PatHospitalAddress { get; set; }

        public string patientsex { get; set; }

        public string ApprovalStatus { get; set; }

        public DateTime? CreationDateTime { get; set; }

        public string CreationUser { get; set; }

        public DateTime LastModifiedDateTime { get; set; }

        public string LastModifiedUser { get; set; }

        public string TreatmentSite { get; set; }

        public string StructureSetId { get; set; }

        public List<STRUCTURE> StructureSet { get; set; }

        // This is chosen by the user and passed on
        public string Laterality { get; set; }

        public string TreatmentOrientation { get; set; }

        // this tells us what the calling program of PlanCheck is, that way we can discriminate the tests we want to perform 
        public string progtype { get; set; }

        public List<BEAM> Beams { get; set; }

        public double BodyBoxXsize { get; set; }

        public double BodyBoxYSize { get; set; }

        public double BodyBoxZSize { get; set; }

        public bool ValidDose { get; set; }

        public string DoseCalcInfo { get; set; }

        public double DoseGridXSize { get; set; }

        public double DoseGridYSize { get; set; }

        public double DoseGridZSize { get; set; }

        public double ImageZsize { get; set; }

        public double ImageZRes { get; set; }
    }

    public class BEAM
    {
        public string Linac { get; set; }

        public string gantrydirection { get; set; }

        public bool setupfield { get; set; }

        public string BolusId { get; set; }

        public Vector3d Isocenter { get; set; }

        public string MLCtype { get; set; }

        // this is supposed to identify if the beam has an enhanced dynamic wedge, but it mught just be any wedge.
        public bool EDWPresent { get; set; }

        public string Technique { get; set; }

        public LMC_CALC_INFO LMCinfo { get; set; }

        public int DoseRate { get; set; } 

        public string EnergyMode { get; set; }

        public double MU { get; set; }

        public string MUunit { get; set; }

        public string beamId { get; set; }

        public double arclength { get; set; }

        public double GantryStartAngle { get; set; }

        public double CouchLongitudinal { get; set; }

        public double CouchLateral { get; set; } 

        public double CouchVertical { get; set; }

        public List<CONTROLPOINT> ControlPoints { get; set; }

        //image stuff put in beam
        public Vector3d imageuserorigin { get; set; }


        public Vector3d imageorigin { get; set; }


        // plan stuff put in beam

        public string planId { get; set; }

        public string patientId { get; set; }

        public string courseId { get; set; }

        public string patientsex { get; set; }

        public string StructureSetId { get; set; }

        public string TreatmentOrientation { get; set; }

        public Vector3d Bodycenter { get; set; }

        public List<Vector3d> Bodyvects { get; set; }

        public List<int> Bodyindices { get; set; }

        public double BodyBoxXsize { get; set; }

        public double BodyBoxYSize { get; set; }

        public double BodyBoxZSize { get; set; }

        public Vector3d CouchInteriorcenter { get; set; }

        public List<Vector3d> CouchInteriorvects { get; set; }

        public List<int> CouchInteriorindices { get; set; }

        public Vector3d BreastBoardcenter { get; set; }

        public List<Vector3d> BreastBoardvects { get; set; }

        public List<int> BreastBoardindices { get; set; }

        public bool couchexists { get; set; }

        public bool breastboardexists { get; set; }

        public string bodylocation { get; set; }

        public double patientheight { get; set; }

    }

    public class CONTROLPOINT
    {
        public double Gantryangle { get; set; }
        public double Couchangle { get; set; }

        //X1 Y1 X2 Y2
        public Tuple<double, double, double, double> JawPositions { get; set; }

        public double CollimatorAngle { get; set; }

        public double MetersetWeight { get; set; }

        public int Index { get; set; }
    }

    public class STRUCTURE
    {
        public Vector3d CenterPoint { get; }

        public Tuple<double, double, double> BoundingBoxBounds { get; }

        public string name { get; }

        public string DicomType { get; }

        public DMesh3 Mesh {get; }

        public STRUCTURE(List<Vector3d> Vertices, List<int> TriIndices, Vector3d inputCenterpoint, string Id, string inputDicomType, Tuple<double, double, double> inputBoundingBoxBounds)
        {
            CenterPoint = inputCenterpoint;
            name = Id;
            BoundingBoxBounds = inputBoundingBoxBounds;
            DicomType = inputDicomType;

            //create mesh
            List<Index3i> ptl = new List<Index3i>();
            Index3i pt = new Index3i();
            int rem = 0;
            int Icount = 0;
            foreach (int I in TriIndices)
            {
                Icount++;
                Math.DivRem(Icount, 3, out rem);
                if (rem == 2)
                {
                    pt.a = I;
                }
                else if (rem == 1)
                {
                    pt.b = I;
                }
                else if (rem == 0)
                {
                    pt.c = I;
                    ptl.Add(pt);
                }
            }

            DMesh3 initmesh = new DMesh3(MeshComponents.VertexNormals);
            for (int i = 0; i < Vertices.Count; i++)
            {
                initmesh.AppendVertex(new NewVertexInfo(Vertices[i]));
            }

            for (int i = 0; i < ptl.Count; i++)
            {
                initmesh.AppendTriangle(ptl[i]);
            }
            Mesh = initmesh;
        }

    }

    public class IMAGE
    {
        public Vector3d imageuserorigin { get; set; }

        public Vector3d imageorigin { get; set; }

    }

    public class PATIENT
    {



    }

    public class COURSE
    {



    }


    public class LMC_CALC_INFO
    {
        public double MaxMUcr1 { get; set; }

        public double MaxMUcr2 { get; set; }

        public double MaxMUcr3 { get; set; }

        public double LostMUfactorCR1 { get; set; }

        public double LostMUfactorCR2 { get; set; }

        public double LostMUfactorCR3 { get; set; }

        public double ActualMU { get; set; }

        public bool LMClog { get; set; }
    }

}
