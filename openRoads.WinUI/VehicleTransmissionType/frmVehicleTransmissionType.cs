using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using openRoads.Model;
using openRoads.WinUI.WFHelpers;

namespace openRoads.WinUI.VehicleTransmissionType
{
    public partial class frmVehicleTransmissionType : Form
    {
        private readonly APIService _service = new APIService("VehicleTransmissionType");

        public frmVehicleTransmissionType()
        {
            InitializeComponent();
        }


        private async void frmVehicleTransmissionType_Load(object sender, EventArgs e)
        {
            var objects = await _service.Get<List<VehicleTransmissionTypeModel>>(null);

            VFormBaseMethods.baseFormForVehicleReferenceModelsLoad(
                WinFormModelTypesList.ModelTypes.VehicleTransmissionTypeModel, dgvVehicleTransmissionTypes, new List<VehicleCategoryModel>(), 
                new List<VehicleFuelTypeModel>(), new List<VehicleTypeModel>(), new List<VehicleManufacturerModel>(),
                objects);
        }

        private void dgvVehicleTransmissionTypes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            VFormBaseMethods.MouseDoubleClick(WinFormModelTypesList.ModelTypes.VehicleTransmissionTypeModel, dgvVehicleTransmissionTypes);
        }
    }
}
