using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;


using Xamarin.Forms;

namespace GeoLocApp_v2
{
    public partial class MainPage : ContentPage
    {
        readonly Services.GeoLocService service = new Services.GeoLocService();

        public MainPage()
        {
            InitializeComponent();
        }


        MissionDataModel missionDataModelSubmitLine;
        //MissionDataModel missionDataModelRecoverLine;

        void Submit (object obj, EventArgs e)
        {
            missionDataModelSubmitLine = new MissionDataModel();
            Button button_submit = (Button) obj;
            string missionName = Input1.Text;
            string missionMaker = Input2.Text;
            string hintL1 = Input3.Text;

            //LabelMN.Text = missionName;
            //LabelMM.Text = missionMaker;
            //LabelHL1.Text = hintL1;

            missionDataModelSubmitLine.missionName = missionName;
            missionDataModelSubmitLine.missionMaker = missionMaker;
            missionDataModelSubmitLine.hintL1 = hintL1;

            service.AddOrUpdateMissionsDataAsync(missionDataModelSubmitLine);
            //return missionDataModelLine;

        }

        public ObservableCollection<MissionDataModel> col;

        async void RecoverAsync(object obj, EventArgs e)
        {
            //missionDataModelRecoverLine = new MissionDataModel();
            Button button_recover = (Button)obj;
            string stuff = service.GetStuff4Async("bego2").ToString();
            LabelFullTable.Text = stuff;
            listf.ItemsSource = await service.GetStuff4Async("bego2");

        }


    }
}
