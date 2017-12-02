using Android.App;
using Android.Widget;
using KodiAndroid.Logic.Service;


namespace KodiAndroid.Logic
{
    internal class DialogBuilder
    {
        public void ShowDialog(Activity cureActivity)
        {

            EditText et = new EditText(cureActivity);
            string button1String = "Вкусная пища";
            string button2String = "Здоровая пища";
            Button cancelButton = new Button(cureActivity);
            AlertDialog.Builder ad = new AlertDialog.Builder(cureActivity);
            ad.SetView(et);
            ad.SetView(cancelButton);
            ad.Show();



            ad.SetTitle("Важное сообщение!");
            ad.SetMessage("Покормите кота!");
            ad.SetPositiveButton(button1String, (s, args) => { sdf(); });
            ad.SetNegativeButton(button2String, (s, args) =>
            {
                cureActivity.RunOnUiThread(() => { ad.Dispose(); });
            });
        }

   

        void sdf()
        {
            var mySetings = new SettingsWorker();
            string iputValue = string.Empty;
            mySetings.Saveset(iputValue, iputValue);
        }

    }
}