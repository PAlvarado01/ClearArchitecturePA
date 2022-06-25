using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.POCOEntities;
using NorthWind.Repositories.EFCore.DataContext;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Presenters;
using NorthWind.Presenters.GetAllOrdersDTO;
using NorthWind.UseCasesDTOs.BulkLoad;
using NorthWind.UseCasesPorts.BulkLoad;
using System.Threading.Tasks;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkLoadController
    {
    readonly IBulkLoadInputPort InputPort;
    readonly IBulkLoadOutputPort OutputPort;

        public BulkLoadController(IBulkLoadInputPort inputPort, IBulkLoadOutputPort outputPort)
        {
            this.InputPort = inputPort;
            this.OutputPort = outputPort;
        }

        [HttpPost("BulkLoad")]
        public async Task<BulkLoadOutput> BulkLoad(IFormFile loadParams)
        {
            await InputPort.Handle(loadParams);

            var Presenter = OutputPort as BulkLoadPresenter;
            return Presenter.Content;
        } 
        /*
        private static IHostingEnvironment _webHost;

        public BulkLoadController(IHostingEnvironment webHost)
        {
            _webHost = webHost;
        }
        
        [HttpPost("CreateBulkLoad")]
        public async Task<string> CreateBulkLoad([FromForm] Archivo obj)
        {
            if (obj.files.Length > 0)
            {
                String FolderPath = Directory.Exists(_webHost.WebRootPath + "\\Images\\").ToString();
                String FileName = obj.files.FileName.ToString();
                String TableName = Dts.Variables["User::TableNameImport"].Value.ToString();
                String SheetName = Dts.Variables["User::SheetName"].Value.ToString();


                var directory = new DirectoryInfo(FolderPath);
                FileInfo[] files = directory.GetFiles();

                //Declare and initilize variables
                string fileFullPath = "";


                fileFullPath = FolderPath + "\\" + FileName;
                //MessageBox.Show(fileFullPath);

                //Create Excel Connection
                string ConStr;
                string HDR;
                HDR = "YES";
                ConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileFullPath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=1\"";
                OleDbConnection cnn = new OleDbConnection(ConStr);

                //Get Sheet Name
                cnn.Open();
                SheetName = SheetName + "$";
                //MessageBox.Show(SheetName);

                //Load the DataTable with Sheet Data
                OleDbCommand oconn = new OleDbCommand("SELECT * FROM [" + SheetName + "]", cnn);
                //cnn.Open();
                OleDbDataAdapter adp = new OleDbDataAdapter(oconn);
                DataTable dt = new DataTable();
                adp.Fill(dt);


                // Create Table if does not exists                
                string tableDDL = "";
                tableDDL += "IF OBJECT_ID('dbo." + TableName + "', 'U') IS NOT NULL ";
                tableDDL += "DROP TABLE dbo." + TableName + " ";
                tableDDL += "IF Not EXISTS (SELECT * FROM sys.objects WHERE object_id = ";
                tableDDL += "OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U'))";
                tableDDL += "CREATE TABLE [" + TableName + "]";
                tableDDL += "(";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i != dt.Columns.Count - 1)
                        tableDDL += "[" + dt.Columns[i].ColumnName.Trim().ToUpper() + "] " + "NVarchar(max)" + ",";
                    else
                        tableDDL += "[" + dt.Columns[i].ColumnName.Trim().ToUpper() + "] " + "NVarchar(max)";
                }
                tableDDL += ")";


                //use ADO.NET connection to Create Table from above Definition
                SqlConnection myADONETConnection = new SqlConnection();
                myADONETConnection = (SqlConnection)(Dts.Connections["TRAMA"].AcquireConnection(Dts.Transaction) as SqlConnection);
                //you can comment the messagebox, it is for debugging
                //MessageBox.Show(tableDDL.ToString());
                SqlCommand myCommand = new SqlCommand(tableDDL, myADONETConnection);
                myCommand.ExecuteNonQuery();
                //Comment this message, it is for debugging
                //MessageBox.Show("TABLE IS CREATED");


                //Load the data from DataTable to SQL Server Table.
                SqlBulkCopy blk = new SqlBulkCopy(myADONETConnection);
                blk.DestinationTableName = "[" + TableName + "]";
                blk.WriteToServer(dt);
                
                Dts.TaskResult = (int)ScriptResults.Success;
                try
                {
                    if (!Directory.Exists(_webHost.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHost.WebRootPath + "\\Images\\");
                    }
                    using (FileStream fileStream = File.Create(_webHost.WebRootPath + "\\Images\\" + obj.files.FileName))
                    {
                        obj.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "\\Images\\" + obj.files.FileName;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Upload Failed";
            }
        }*/
    }
}
