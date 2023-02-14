using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Convert_App
{
    public partial class MainPage : ContentPage
    {
        List<string> PickerItems = new List<string>();

        public MainPage()
        {
            InitializeComponent();
        }

        public string lastanswer = "";
        public string convertType = "Temperature";

        public string InputType = "";
        public string OutputType = "";

        public Button lastBtn;
        
        public ApplicationVariables Appvars = new ApplicationVariables();

        //Customer object1 = new Customer();


        private void InputPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                if (convertType == "Acceleration") { Appvars.Acceleration[0] = selectedIndex; }
                else if (convertType == "Amt. of Substance") { Appvars.AmtOfSubstance[0] = selectedIndex; }
                else if (convertType == "Angle") { Appvars.Angle[0] = selectedIndex; }
                else if (convertType == "Area") { Appvars.Area[0] = selectedIndex; }
                else if (convertType == "Computer") { Appvars.Computer[0] = selectedIndex; }
                else if (convertType == "Concentration") { Appvars.Concentration[0] = selectedIndex; }
                else if (convertType == "Density") { Appvars.Density[0] = selectedIndex; }
                else if (convertType == "Distance") { Appvars.Distance[0] = selectedIndex; }
                else if (convertType == "Energy") { Appvars.Energy[0] = selectedIndex; }
                else if (convertType == "Flow") { Appvars.Flow[0] = selectedIndex; }
                else if (convertType == "Force") { Appvars.Force[0] = selectedIndex; }
                else if (convertType == "Light") { Appvars.Light[0] = selectedIndex; }
                else if (convertType == "Mass") { Appvars.Mass[0] = selectedIndex; }
                else if (convertType == "Power") { Appvars.Power[0] = selectedIndex; }
                else if (convertType == "Pressure") { Appvars.Pressure[0] = selectedIndex; }
                else if (convertType == "Speed") { Appvars.Speed[0] = selectedIndex; }
                else if (convertType == "Temperature") { Appvars.Temperature[0] = selectedIndex; }
                else if (convertType == "Time") { Appvars.Time[0] = selectedIndex; }
                else if (convertType == "Torque") { Appvars.Torque[0] = selectedIndex; }
                else if (convertType == "Volume") { Appvars.Volume[0] = selectedIndex; }
                InputType = $"{InputPicker.Items[selectedIndex]}";
                if (InputType != "" && OutputType != "")
                {
                    InputChanged(InputValue.Text, true);
                }
            }
        }

        private void OutputPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                if (convertType == "Acceleration") { Appvars.Acceleration[1] = selectedIndex; }
                else if (convertType == "Amt. of Substance") { Appvars.AmtOfSubstance[1] = selectedIndex; }
                else if (convertType == "Angle") { Appvars.Angle[1] = selectedIndex; }
                else if (convertType == "Area") { Appvars.Area[1] = selectedIndex; }
                else if (convertType == "Computer") { Appvars.Computer[1] = selectedIndex; }
                else if (convertType == "Concentration") { Appvars.Concentration[1] = selectedIndex; }
                else if (convertType == "Density") { Appvars.Density[1] = selectedIndex; }
                else if (convertType == "Distance") { Appvars.Distance[1] = selectedIndex; }
                else if (convertType == "Energy") { Appvars.Energy[1] = selectedIndex; }
                else if (convertType == "Flow") { Appvars.Flow[1] = selectedIndex; }
                else if (convertType == "Force") { Appvars.Force[1] = selectedIndex; }
                else if (convertType == "Light") { Appvars.Light[1] = selectedIndex; }
                else if (convertType == "Mass") { Appvars.Mass[1] = selectedIndex; }
                else if (convertType == "Power") { Appvars.Power[1] = selectedIndex; }
                else if (convertType == "Pressure") { Appvars.Pressure[1] = selectedIndex; }
                else if (convertType == "Speed") { Appvars.Speed[1] = selectedIndex; }
                else if (convertType == "Temperature") { Appvars.Temperature[1] = selectedIndex; }
                else if (convertType == "Time") { Appvars.Time[1] = selectedIndex; }
                else if (convertType == "Torque") { Appvars.Torque[1] = selectedIndex; }
                else if (convertType == "Volume") { Appvars.Volume[1] = selectedIndex; }

                OutputType = $"{OutputPicker.Items[selectedIndex]}";

                if (InputType != "" && OutputType != "")
                {
                    InputChanged(InputValue.Text, true);
                }
            }

        }


        void OnInputChanged(object sender, EventArgs e)
        {

            Entry searchBar = (Entry)sender;
            String str1 = searchBar.Text;
            if (InputType != "" && OutputType != "")
            {
                InputChanged(str1, false);
            }

        }

        void InputChanged(string str1, Boolean bool1)
        {

            //Outthing.Text = OutputType;
            //Inthing.Text = InputType;


            if (str1 != lastanswer || bool1 == true)
            {
                double inputValue;
                bool isNumber = Double.TryParse(str1, out inputValue);
                if (isNumber == true)
                {
                    double answer = round(FindAnswer(inputValue, true));
                    lastanswer = $"{answer}";
                    inputValue = answer;
                    OutputValue.Text = $"{inputValue}";
                }
                else
                {
                    OutputValue.Text = "";
                    lastanswer = "";
                }
            }
        }




        void OnOutputChanged(object sender, EventArgs e)
        {
            Entry searchBar = (Entry)sender;
            String str1 = searchBar.Text;
            if (InputType != "" && OutputType != "")
            {
                OutputChanged(str1, false);
            }

        }

        void OutputChanged(string str1, Boolean bool1)
        {

            //Outthing.Text = OutputType;
            //Inthing.Text = InputType;

            if (str1 != lastanswer || bool1 == true)
            {
                double outPutValue;
                bool isNumber = Double.TryParse(str1, out outPutValue);
                if (isNumber == true)
                {
                    double answer = round(FindAnswer(outPutValue, false));
                    lastanswer = $"{answer}";
                    outPutValue = answer;
                    InputValue.Text = $"{outPutValue}";
                }
                else
                {
                    InputValue.Text = "";
                    lastanswer = "";
                }
            }
        }



        //Rounding
        public static double round(double num)
        {
            long roundTo = 10000000000;
            return Math.Round(num * roundTo) / roundTo;
        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            Appvars.Acceleration[1] = 5;
        }

        private void changePickers(Button btn1)
        {

            if (lastBtn != null)
            {
                lastBtn.BackgroundColor = Color.LightGray;
            }
            if (btn1.BackgroundColor != Color.Green)
            {
                btn1.BackgroundColor = Color.Green;
            }
            lastBtn = btn1;

            int[] pickerIndexs = {2};


            PickerItems.Clear();
            InputPicker.ItemsSource = new List<string>();
            OutputPicker.ItemsSource = new List<string>();

            if(convertType == "Acceleration")
            {
                PickerItems.Add("cm/s^2");
                PickerItems.Add("ft/s^2");
                PickerItems.Add("free fall (g)");
                PickerItems.Add("m/s^2");
                PickerItems.Add("mile/(h * s)");
                PickerItems.Add("mm/s^2");
                pickerIndexs = Appvars.Acceleration;
            }

            else if (convertType == "Amt. of Substance")
            {
                PickerItems.Add("kilomole (kmol)");
                PickerItems.Add("micromole (μmol)");
                PickerItems.Add("milimole (mmol)");
                PickerItems.Add("mole (mol)");
                pickerIndexs = Appvars.AmtOfSubstance;
            }

            else if (convertType == "Angle")
            {
                PickerItems.Add("degree (°)");
                PickerItems.Add("grad (g)");
                PickerItems.Add("minute (')");
                PickerItems.Add("radian (rad)");
                PickerItems.Add("revolution (r)");
                PickerItems.Add("right angle");
                PickerItems.Add("second ('')");
                pickerIndexs = Appvars.Angle;
            }

            else if (convertType == "Area")
            {
                PickerItems.Add("acre");
                PickerItems.Add("centimeter^2");
                PickerItems.Add("foot^2");
                PickerItems.Add("hectare");
                PickerItems.Add("inch^2");
                PickerItems.Add("kilometer^2 (km^2)");
                PickerItems.Add("meter^2");
                PickerItems.Add("mile^2");
                PickerItems.Add("milimeter^2");
                PickerItems.Add("yard^2");
                pickerIndexs = Appvars.Area;
            }

            else if (convertType == "Computer")
            {
                PickerItems.Add("bit");
                PickerItems.Add("byte");
                PickerItems.Add("exabyte");
                PickerItems.Add("gigabyte");
                PickerItems.Add("kilobit");
                PickerItems.Add("kilobyte");
                PickerItems.Add("megabit");
                PickerItems.Add("megabyte");
                PickerItems.Add("nibble");
                PickerItems.Add("petabyte");
                PickerItems.Add("terabyte");
                PickerItems.Add("yottabyte");
                PickerItems.Add("zettabyte");
                pickerIndexs = Appvars.Computer;
            }

            else if (convertType == "Concentration")
            {
                PickerItems.Add("kmol/m^3");
                PickerItems.Add("μmol/cm^3");
                PickerItems.Add("μmol/dm^3");
                PickerItems.Add("μmol/L");
                PickerItems.Add("mmol/cm^3");
                PickerItems.Add("mmol/dm^3");
                PickerItems.Add("mmol/L");
                PickerItems.Add("mmol/m^3");
                PickerItems.Add("mmol/mL");
                PickerItems.Add("mol/dm^3");
                PickerItems.Add("mol/L");
                PickerItems.Add("mol/m^3");
                PickerItems.Add("entity/meter^3");
                pickerIndexs = Appvars.Concentration;
            }

            else if (convertType == "Density")
            {
                PickerItems.Add("gram/centimeter^3");
                PickerItems.Add("gram/meter^3");
                PickerItems.Add("kilogram/meter^3");
                PickerItems.Add("miligram/meter^3");
                PickerItems.Add("ounce/gallon");
                PickerItems.Add("pound/foot^3");
                PickerItems.Add("pound/inch^3");
                PickerItems.Add("ton/yard^3");
                pickerIndexs = Appvars.Density;
            }

            else if (convertType == "Distance")
            {
                PickerItems.Add("centimeter (cm)");
                PickerItems.Add("dekameter (dm)");
                PickerItems.Add("foot (ft)");
                PickerItems.Add("furlong");
                PickerItems.Add("hectometer (hm)");
                PickerItems.Add("inch (in)");
                PickerItems.Add("kilometer (km)");
                PickerItems.Add("lightyear");
                PickerItems.Add("meter (m)");
                PickerItems.Add("micrometer (μm)");
                PickerItems.Add("mil (mil)");
                PickerItems.Add("mile (mil)");
                PickerItems.Add("milimeter (mm)");
                PickerItems.Add("nanometer (nm)");
                PickerItems.Add("nautical mile (M)");
                PickerItems.Add("parsec (pc)");
                PickerItems.Add("yard (yd)");
                pickerIndexs = Appvars.Distance;

            }

            else if (convertType == "Energy")
            {
                PickerItems.Add("attojoule");
                PickerItems.Add("BTU");
                PickerItems.Add("calorie");
                PickerItems.Add("dyne-centimeter");
                PickerItems.Add("electron volt");
                PickerItems.Add("erg");
                PickerItems.Add("gigajoule");
                PickerItems.Add("gigawatt-hour");
                PickerItems.Add("gram force-centimeter");
                PickerItems.Add("horsepower-hour");
                PickerItems.Add("joule");
                PickerItems.Add("kilocalorie");
                PickerItems.Add("kiloelectron volt");
                PickerItems.Add("kilojoule");
                PickerItems.Add("kilowatt-hour");
                PickerItems.Add("megaelecron volt");
                PickerItems.Add("megajoule");
                PickerItems.Add("megawatt-hour");
                PickerItems.Add("microjoule");
                PickerItems.Add("milijoule");
                PickerItems.Add("nanojoule");
                PickerItems.Add("newton-meter");
                PickerItems.Add("ounce force-inch");
                PickerItems.Add("pound force-foot");
                PickerItems.Add("pound force-inch");
                PickerItems.Add("poundal-foot");
                PickerItems.Add("therm");
                PickerItems.Add("watt-hour");
                PickerItems.Add("watt-second");
                pickerIndexs = Appvars.Energy;
            }

            else if (convertType == "Flow")
            {
                PickerItems.Add("centimeter^3/hour");
                PickerItems.Add("centimeter^3/minute");
                PickerItems.Add("centimeter^3/second");
                PickerItems.Add("foot^3/hour");
                PickerItems.Add("foot^3/minute");
                PickerItems.Add("foot^3/second");
                PickerItems.Add("gallon (UK)/day");
                PickerItems.Add("gallon (UK)/hour");
                PickerItems.Add("gallon (UK)/minute");
                PickerItems.Add("gallon (UK)/second");
                PickerItems.Add("gallon/day");
                PickerItems.Add("gallon/hour");
                PickerItems.Add("gallon/minute");
                PickerItems.Add("gallon/second");
                PickerItems.Add("liter/day");
                PickerItems.Add("liter/hour");
                PickerItems.Add("liter/minute");
                PickerItems.Add("liter/second");
                PickerItems.Add("meter^3/day");
                PickerItems.Add("meter^3/hour");
                PickerItems.Add("meter^3/minute");
                PickerItems.Add("meter^3/second");
                PickerItems.Add("milliliter/hour");
                PickerItems.Add("milliliter/minute");
                PickerItems.Add("milliliter/second");
                PickerItems.Add("ounce (UK)/hour");
                PickerItems.Add("ounce (UK)/minute");
                PickerItems.Add("ounce (UK)/second");
                PickerItems.Add("ounce/hour");
                PickerItems.Add("ounce/minute");
                PickerItems.Add("ounce/second");
                PickerItems.Add("yard^3/hour");
                PickerItems.Add("yard^3/minute");
                PickerItems.Add("yard^3/second");
                pickerIndexs = Appvars.Flow;
            }

            else if (convertType == "Force")
            {
                PickerItems.Add("dyne");
                PickerItems.Add("gram force");
                PickerItems.Add("kilogram force");
                PickerItems.Add("kilonewton");
                PickerItems.Add("milinewton");
                PickerItems.Add("newton");
                PickerItems.Add("ounce-force (ozf)");
                PickerItems.Add("pound-force (lbf)");
                pickerIndexs = Appvars.Force;
            }

            else if (convertType == "Light")
            {
                PickerItems.Add("flame");
                PickerItems.Add("foot-candles");
                PickerItems.Add("lux");
                PickerItems.Add("meter-candles");
                pickerIndexs = Appvars.Light;
            }

            else if (convertType == "Mass")
            {
                PickerItems.Add("carat");
                PickerItems.Add("grain (gr)");
                PickerItems.Add("gram (g)");
                PickerItems.Add("kilogram (kg)");
                PickerItems.Add("megagram (Mg)");
                PickerItems.Add("microgram (μg)");
                PickerItems.Add("miligram (mg)");
                PickerItems.Add("ounce (avdp) (oz)");
                PickerItems.Add("ounce (troy) (ozt)");
                PickerItems.Add("pennyweight");
                PickerItems.Add("pound (advp) (lb)");
                PickerItems.Add("pound (troy)");
                PickerItems.Add("stone");
                PickerItems.Add("ton (long)");
                PickerItems.Add("ton (short) (tn)");
                PickerItems.Add("tonne (metric ton) (t)");
                pickerIndexs = Appvars.Mass;
            }

            else if (convertType == "Power")
            {
                PickerItems.Add("BTU/hour");
                PickerItems.Add("BTU/minute");
                PickerItems.Add("BTU/second");
                PickerItems.Add("calorie/second");
                PickerItems.Add("horsepower");
                PickerItems.Add("kilowatt");
                PickerItems.Add("megawatt");
                PickerItems.Add("pound-feet/minute");
                PickerItems.Add("pound-fee/second");
                PickerItems.Add("watt");
                pickerIndexs = Appvars.Power;
            }

            else if (convertType == "Pressure")
            {
                PickerItems.Add("atmosphere");
                PickerItems.Add("bar");
                PickerItems.Add("centimeters of mercury");
                PickerItems.Add("dyne/centimeter^2");
                PickerItems.Add("inches of mercury");
                PickerItems.Add("kilogram/centimeter^2");
                PickerItems.Add("kilogram/meter^2");
                PickerItems.Add("kilopascal");
                PickerItems.Add("megapascal");
                PickerItems.Add("microbar");
                PickerItems.Add("milibar");
                PickerItems.Add("milimeters of mercury");
                PickerItems.Add("pascal");
                PickerItems.Add("pound/foot^2");
                PickerItems.Add("pound/inch^2");
                PickerItems.Add("PSI");
                PickerItems.Add("ton/foot^2");
                PickerItems.Add("ton/inch^2");
                PickerItems.Add("torr");
                pickerIndexs = Appvars.Pressure;
            }

            else if (convertType == "Speed")
            {
                PickerItems.Add("C");
                PickerItems.Add("centimeter/hour");
                PickerItems.Add("centimeter/minute");
                PickerItems.Add("centimeter/second");
                PickerItems.Add("foot/hour");
                PickerItems.Add("foot/minute");
                PickerItems.Add("foot/second");
                PickerItems.Add("kilometer/hour");
                PickerItems.Add("kilometer/minute");
                PickerItems.Add("kilometer/second");
                PickerItems.Add("knot");
                PickerItems.Add("mach");
                PickerItems.Add("meter/hour");
                PickerItems.Add("meter/minute");
                PickerItems.Add("meter/second");
                PickerItems.Add("mile/hour");
                PickerItems.Add("mile/minute");
                PickerItems.Add("mile/second");
                pickerIndexs = Appvars.Speed;
            }

            else if (convertType == "Temperature")
            {
                PickerItems.Add("°C");
                PickerItems.Add("°F");
                PickerItems.Add("°K");
                PickerItems.Add("°R");
                pickerIndexs = Appvars.Temperature;
            }

            else if (convertType == "Time")
            {
                PickerItems.Add("century");
                PickerItems.Add("day");
                PickerItems.Add("decade");
                PickerItems.Add("fortnight");
                PickerItems.Add("hour");
                PickerItems.Add("leap-year");
                PickerItems.Add("millennium");
                PickerItems.Add("milisecond");
                PickerItems.Add("minute (')");
                PickerItems.Add("month (30 day)");
                PickerItems.Add("nanosecond");
                PickerItems.Add("second ('')");
                PickerItems.Add("week");
                PickerItems.Add("year");
                pickerIndexs = Appvars.Time;

            }

            else if (convertType == "Torque")
            {
                PickerItems.Add("dyne centimeter (dyn • cm)");
                PickerItems.Add("gram-force centimeter (gf • cm)");
                PickerItems.Add("kilogram-force meter (kgf • m)");
                PickerItems.Add("kilonewton meter (kN • m)");
                PickerItems.Add("kilopond meter (kp • m)");
                PickerItems.Add("meganewton meter (MN • m)");
                PickerItems.Add("micronewton meter (μN • m)");
                PickerItems.Add("milinewton meter (mN • m)");
                PickerItems.Add("newton meter (N • m)");
                PickerItems.Add("ounce-force foot (ozf • ft)");
                PickerItems.Add("ounce-force inch (ozf • in)");
                PickerItems.Add("pound-force foot (lbf • ft)");
                PickerItems.Add("pound-force inch (lbf • in)");
                pickerIndexs = Appvars.Torque;
            }

            else if (convertType == "Volume")
            {
                PickerItems.Add("CC");
                PickerItems.Add("cubic centimeter");
                PickerItems.Add("cubic foot");
                PickerItems.Add("cubic inch");
                PickerItems.Add("cubic meter");
                PickerItems.Add("cubic yard");
                PickerItems.Add("cup");
                PickerItems.Add("dram");
                PickerItems.Add("drop");
                PickerItems.Add("gallon");
                PickerItems.Add("gallon (UK)");
                PickerItems.Add("liter");
                PickerItems.Add("milliliter");
                PickerItems.Add("minim (US)");
                PickerItems.Add("ounce (oz)");
                PickerItems.Add("ounce (oz) (UK)");
                PickerItems.Add("pint (pt)");
                PickerItems.Add("pint (pt) (UK)");
                PickerItems.Add("quart");
                PickerItems.Add("tablespoon");
                PickerItems.Add("teaspoon");
                pickerIndexs = Appvars.Volume;
            }



            lastanswer = "";
            InputType = "";
            OutputType = "";

            InputPicker.ItemsSource = PickerItems;
            OutputPicker.ItemsSource = PickerItems;

            InputPicker.SelectedIndex = pickerIndexs[0];
            OutputPicker.SelectedIndex = pickerIndexs[1];
        }


        private void ChangeMode_Button(object sender, EventArgs e)
        {
            Button btn1 = (Button)sender;
            convertType = btn1.Text;
            changePickers(btn1);
        }



        public double FindAnswer(double input, Boolean Inprimary)
        {
            String In = "";
            String Out = "";
            if (Inprimary == true)
            {
                In = InputType;
                Out = OutputType;
            }
            else if (Inprimary == false)
            {
                In = OutputType;
                Out = InputType;
            }
            if(In == Out)
            {
                return input;
            }
            if(convertType == "Acceleration")
            {
                double metersS2 = input;

                if (In == "cm/s^2") { metersS2 = input / 100; }
                else if (In == "ft/s^2") { metersS2 = input / 3.281; }
                else if (In == "free fall (g)") { metersS2 = input * 9.8; }
                else if (In == "mile/(h * s)") { metersS2 = input / 2.23694; }
                else if (In == "mm/s^2") { metersS2 = input / 1000; }

                if (Out == "m/s^2") { return metersS2; }
                else if (Out == "cm/s^2") { return metersS2 * 100; }
                else if (Out == "ft/s^2") { return metersS2 * 3.281; }
                else if (Out == "free fall (g)") { return metersS2 / 9.8; }
                else if (Out == "mile/(h * s)") { return metersS2 * 2.23694; }
                else if (Out == "mm/s^2") { return metersS2 * 1000; }
            }
            if (convertType == "Amt. of Substance")
            {
                double moles = input;

                if (In == "kilomole (kmol)") { moles = input * 1000; }
                else if (In == "micromole (μmol)") { moles = input / 1000000; }
                else if (In == "milimole (mmol)") { moles = input / 1000; }


                if (Out == "mole (mol)") { return moles; }
                else if (Out == "kilomole (kmol)") { return moles / 1000; }
                else if (Out == "micromole (μmol)") { return moles * 1000000; }
                else if (Out == "milimole (mmol)") { return moles * 1000; }
            }
            else if (convertType == "Angle")
            {
                double degree = input;

                if (In == "grad (g)") { degree = input * 0.9; }
                else if (In == "minute (')") { degree = input / 60; }
                else if (In == "radian (rad)") { degree = input / (Math.PI / 180); }
                else if (In == "revolution (r)") { degree = input * 360; }
                else if (In == "right angle") { degree = input * 90; }
                else if (In == "second ('')") { degree = input / 3600; }

                if (Out == "degree (°)") { return degree; }
                else if (Out == "grad (g)") { return degree / 0.9; }
                else if (Out == "minute (')") { return degree * 60; }
                else if (Out == "radian (rad)") { return degree * Math.PI / 180; }
                else if (Out == "revolution (r)") { return degree / 360; }
                else if (Out == "right angle") { return degree / 90; }
                else if (Out == "second ('')") { return degree * 3600; }

            }
            else if (convertType == "Area")
            {
                double acre = input;

                if (In == "centimeter^2") { acre = input / 40470000; }
                else if (In == "foot^2") { acre = input / 43560; }
                else if (In == "hectare") { acre = input * 2.471; }
                else if (In == "inch^2") { acre = input / 6272640; }
                else if (In == "kilometer^2 (km^2)") { acre = input * 247.1; }
                else if (In == "meter^2") { acre = input / 4046.86; }
                else if (In == "mile^2") { acre = input * 640; }
                else if (In == "milimeter^2") { acre = input / 4047000000; }
                else if (In == "yard^2") { acre = input / 4840; }

                if (Out == "acre") { return acre; }
                else if (Out == "centimeter^2") { return acre * 40470000; }
                else if (Out == "foot^2") { return acre * 43560; }
                else if (Out == "hectare") { return acre / 2.471; }
                else if (Out == "inch^2") { return acre * 6272640; }
                else if (Out == "kilometer^2 (km^2)") { return acre / 247.1; }
                else if (Out == "meter^2") { return acre * 4046.86; }
                else if (Out == "mile^2") { return acre / 640; }
                else if (Out == "milimeter^2") { return acre * 4047000000; }
                else if (Out == "yard^2") { return acre * 4840; }

            }
            else if (convertType == "Computer")
            {
                double kilobyte = input;

                if (In == "bit") { kilobyte = input / 8000; }
                else if (In == "byte") { kilobyte = input / 1000; }
                else if (In == "exabyte") { kilobyte = input * 1000000000000000; }
                else if (In == "gigabyte") { kilobyte = input * 1000000; }
                else if (In == "kilobit") { kilobyte = input / 8; }
                else if (In == "megabit") { kilobyte = input * 125; }
                else if (In == "megabyte") { kilobyte = input * 1000; }
                else if (In == "nibble") { kilobyte = input / 2000; }
                else if (In == "petabyte") { kilobyte = input * 1000000000000; }
                else if (In == "terabyte") { kilobyte = input * 1000000000; }
                else if (In == "yottabyte") { kilobyte = input * 1000000000000000000 * 1000; }
                else if (In == "zettabyte") { kilobyte = input * 1000000000000000000; }

                if (Out == "kilobyte") { return kilobyte; }
                else if (Out == "bit") { return kilobyte * 8000; }
                else if (Out == "byte") { return kilobyte * 1000; }
                else if (Out == "exabyte") { return kilobyte / 1000000000000000; }
                else if (Out == "gigabyte") { return kilobyte / 1000000; }
                else if (Out == "kilobit") { return kilobyte * 8; }
                else if (Out == "megabit") { return kilobyte / 125; }
                else if (Out == "megabyte") { return kilobyte / 1000; }
                else if (Out == "nibble") { return kilobyte * 2000; }
                else if (Out == "petabyte") { return kilobyte / 1000000000000; }
                else if (Out == "terabyte") { return kilobyte / 1000000000; }
                else if (Out == "yottabyte") { return kilobyte / 1000000000000000000 / 1000; }
                else if (Out == "zettabyte") { return kilobyte / 1000000000000000000; }
            }

            else if (convertType == "Concentration")
            {
                double molL = input;

                if (In == "kmol/m^3") { molL = input; }
                else if (In == "μmol/cm^3") { molL = input / 1000; }
                else if (In == "μmol/dm^3") { molL = input / 1000000; }
                else if (In == "μmol/L") { molL = input / 1000000; }
                else if (In == "mmol/cm^3") { molL = input; }
                else if (In == "mmol/dm^3") { molL = input / 1000; }
                else if (In == "mmol/L") { molL = input / 1000; }
                else if (In == "mmol/m^3") { molL = input / 1000000; }
                else if (In == "mmol/mL") { molL = input; }
                else if (In == "mol/dm^3") { molL = input; }
                else if (In == "mol/m^3") { molL = input / 1000; }
                else if (In == "entity/meter^3") { molL = input / (6.02214076 * Math.Pow(10, 26)); }

                if (Out == "mol/L") { return molL; }
                else if (Out == "kmol/m^3") { return molL; }
                else if (Out == "μmol/cm^3") { return molL * 1000; }
                else if (Out == "μmol/dm^3") { return molL * 1000000; }
                else if (Out == "μmol/L") { return molL * 1000000; }
                else if (Out == "mmol/cm^3") { return molL; }
                else if (Out == "mmol/dm^3") { return molL * 1000; }
                else if (Out == "mmol/L") { return molL * 1000; }
                else if (Out == "mmol/m^3") { return molL * 1000000; }
                else if (Out == "mmol/mL") { return molL; }
                else if (Out == "mol/dm^3") { return molL; }
                else if (Out == "mol/m^3") { return molL * 1000; }
                else if (Out == "entity/meter^3") { return molL * (6.02214076 * Math.Pow(10, 26)); }

            }

            else if (convertType == "Density")
            {
                double gramCentimeter3 = input;

                if (In == "gram/meter^3") { gramCentimeter3 = input / 1000000; }
                else if (In == "kilogram/meter^3") { gramCentimeter3 = input / 1000; }
                else if (In == "miligram/meter^3") { gramCentimeter3 = input / 1000000000; }
                else if (In == "ounce/gallon") { gramCentimeter3 = input / 133.5; }
                else if (In == "pound/foot^3") { gramCentimeter3 = input / 62.428; }
                else if (In == "pound/inch^3") { gramCentimeter3 = input * 27.68; }
                else if (In == "ton/yard^3") { gramCentimeter3 = input * 1.187; }

                if (Out == "gram/centimeter^3") { return gramCentimeter3; }
                else if (Out == "gram/meter^3") { return gramCentimeter3 * 1000000; }
                else if (Out == "kilogram/meter^3") { return gramCentimeter3 * 1000; }
                else if (Out == "miligram/meter^3") { return gramCentimeter3 * 1000000000; }
                else if (Out == "ounce/gallon") { return gramCentimeter3 * 133.5; }
                else if (Out == "pound/foot^3") { return gramCentimeter3 * 62.428; }
                else if (Out == "pound/inch^3") { return gramCentimeter3 / 27.68; }
                else if (Out == "ton/yard^3") { return gramCentimeter3 / 1.187; }

            }

            else if (convertType == "Distance")
            {
                double centimeter = input;

                if (In == "dekameter (dm)") { centimeter = input * 1000; }
                else if (In == "foot (ft)") { centimeter = input * 30.48; }
                else if (In == "furlong") { centimeter = input * 20120; }
                else if (In == "hectometer (hm)") { centimeter = input * 10000; }
                else if (In == "inch (in)") { centimeter = input * 2.54; }
                else if (In == "kilometer (km)") { centimeter = input * 100000; }
                else if (In == "lightyear") { centimeter = input * (9.461 * Math.Pow(10, 17)); }
                else if (In == "meter (m)") { centimeter = input * 100; }
                else if (In == "micrometer (μm)") { centimeter = input / 10000; }
                else if (In == "mil (mil)") { centimeter = input / 393.7; }
                else if (In == "mile (mil)") { centimeter = input * 160900; }
                else if (In == "milimeter (mm)") { centimeter = input / 10; }
                else if (In == "nanometer (nm)") { centimeter = input / 10000000; }
                else if (In == "nautical mile (M)") { centimeter = input * 185200; }
                else if (In == "parsec (pc)") { centimeter = input * (3.086 * Math.Pow(10, 18)); }
                else if (In == "yard (yd)") { centimeter = input * 91.44; }

                if (Out == "centimeter (cm)") { return centimeter; }
                else if (Out == "dekameter (dm)") { return centimeter / 1000; }
                else if (Out == "foot (ft)") { return centimeter / 30.48; }
                else if (Out == "furlong") { return centimeter / 20120; }
                else if (Out == "hectometer (hm)") { return centimeter / 10000; }
                else if (Out == "inch (in)") { return centimeter / 2.54; }
                else if (Out == "kilometer (km)") { return centimeter / 100000; }
                else if (Out == "lightyear") { return centimeter / (9.461 * Math.Pow(10, 17)); }
                else if (Out == "meter (m)") { return centimeter / 100; }
                else if (Out == "micrometer (μm)") { return centimeter * 10000; }
                else if (Out == "mil (mil)") { return centimeter * 393.7; }
                else if (Out == "mile (mil)") { return centimeter / 160900; }
                else if (Out == "milimeter (mm)") { return centimeter * 10; }
                else if (Out == "nanometer (nm)") { return centimeter * 10000000; }
                else if (Out == "nautical mile (M)") { return centimeter / 185200; }
                else if (Out == "parsec (pc)") { return centimeter / (3.086 * Math.Pow(10, 18)); }
                else if (Out == "yard (yd)") { return centimeter / 91.44; }
            }

            else if (convertType == "Energy")
            {
                double kilojoule = input;

                if (In == "attojoule") { kilojoule = input / Math.Pow(10, 21); }
                else if (In == "BTU") { kilojoule = input * 1.055; }
                else if (In == "calorie") { kilojoule = input / 238.8459; }
                else if (In == "dyne-centimeter") { kilojoule = input / Math.Pow(10, 10); }
                else if (In == "electron volt") { kilojoule = input / (6.242 * Math.Pow(10, 21)); }
                else if (In == "erg") { kilojoule = input / Math.Pow(10, 10); }
                else if (In == "gigajoule") { kilojoule = input * Math.Pow(10, 10); }
                else if (In == "gigawatt-hour") { kilojoule = input * (3.6 * Math.Pow(10, 9)); }
                else if (In == "gram force-centimeter") { kilojoule = input / 10197162; }
                else if (In == "horsepower-hour") { kilojoule = input / 0.0003725061; }
                else if (In == "joule") { kilojoule = input / 1000; }
                else if (In == "kilocalorie") { kilojoule = input * 4.184; }
                else if (In == "kiloelectron volt") { kilojoule = input / (6.242 * Math.Pow(10, 18)); }
                else if (In == "kilowatt-hour") { kilojoule = input * 3600; }
                else if (In == "megaelecron volt") { kilojoule = input / (6.242 * Math.Pow(10, 15)); }
                else if (In == "megajoule") { kilojoule = input * 1000; }
                else if (In == "megawatt-hour") { kilojoule = input * 3600000; }
                else if (In == "microjoule") { kilojoule = input / Math.Pow(10, 9); }
                else if (In == "milijoule") { kilojoule = input / 1000000; }
                else if (In == "nanojoule") { kilojoule = input / Math.Pow(10, 12); }
                else if (In == "newton-meter") { kilojoule = input / 1000; }
                else if (In == "ounce force-inch") { kilojoule = input / 141611.93; }
                else if (In == "pound force-foot") { kilojoule = input / 737.5621493; }
                else if (In == "pound force-inch") { kilojoule = input / 8850.7457916; }
                else if (In == "poundal-foot") { kilojoule = input / 23730.36; }
                else if (In == "therm") { kilojoule = input * 105500;  }
                else if (In == "watt-hour") { kilojoule = input * 3.6; }
                else if (In == "watt-second") { kilojoule = input / 1000; }

                if (Out == "kilojoule") { return kilojoule; }
                else if (Out == "attojoule") { return kilojoule * Math.Pow(10, 21); }
                else if (Out == "BTU") { return kilojoule / 1.055; }
                else if (Out == "calorie") { return kilojoule * 238.8459; }
                else if (Out == "dyne-centimeter") { return kilojoule * Math.Pow(10, 10); }
                else if (Out == "electron volt") { return kilojoule * 6.242 * Math.Pow(10, 21); }
                else if (Out == "erg") { return kilojoule * Math.Pow(10, 10); }
                else if (Out == "gigajoule") { return kilojoule / Math.Pow(10, 6); }
                else if (Out == "gigawatt-hour") { return kilojoule / (3.6 * Math.Pow(10, 9)); }
                else if (Out == "gram force-centimeter") { return kilojoule * 10197162; }
                else if (Out == "horsepower-hour") { return kilojoule * 0.0003725061; }
                else if (Out == "joule") { return kilojoule * 1000; }
                else if (Out == "kilocalorie") { return kilojoule / 4.184; }
                else if (Out == "kiloelectron volt") { return kilojoule * 6.242 * Math.Pow(10, 18); }
                else if (Out == "kilowatt-hour") { return kilojoule / 3600; }
                else if (Out == "megaelecron volt") { return kilojoule * (6.242 * Math.Pow(10, 15)); }
                else if (Out == "megajoule") { return kilojoule / 1000; }
                else if (Out == "megawatt-hour") { return kilojoule / 3600000; }
                else if (Out == "microjoule") { return kilojoule * Math.Pow(10, 9); }
                else if (Out == "milijoule") { return kilojoule * 1000000; }
                else if (Out == "nanojoule") { return kilojoule * Math.Pow(10, 12); }
                else if (Out == "newton-meter") { return kilojoule * 1000; }
                else if (Out == "ounce force-inch") { return kilojoule * 141611.93; }
                else if (Out == "pound force-foot") { return kilojoule * 737.5621493; }
                else if (Out == "pound force-inch") { return kilojoule * 8850.7457916; }
                else if (Out == "poundal-foot") { return kilojoule * 23730.36; }
                else if (Out == "therm") { return kilojoule / 105500; }
                else if (Out == "watt-hour") { return kilojoule / 3.6; }
                else if (Out == "watt-second") { return kilojoule * 1000; }
            }
            else if (convertType == "Flow")
            {
                double centimeter3hour = input;

                if (In == "centimeter^3/minute") { centimeter3hour = input * 60; }
                else if (In == "centimeter^3/second") { centimeter3hour = input * 3600; }
                else if (In == "foot^3/hour") { centimeter3hour = input * 28320; }
                else if (In == "foot^3/minute") { centimeter3hour = input * 1699000; }
                else if (In == "foot^3/second") { centimeter3hour = input * 101900000; }
                else if (In == "gallon (UK)/day") { centimeter3hour = input * 189.420486962; }
                else if (In == "gallon (UK)/hour") { centimeter3hour = input * 4546.09099819; }
                else if (In == "gallon (UK)/minute") { centimeter3hour = input * 272765.484692; }
                else if (In == "gallon (UK)/second") { centimeter3hour = input * 16365931.76; }
                else if (In == "gallon/day") { centimeter3hour = input * 157.7; }
                else if (In == "gallon/hour") { centimeter3hour = input * 3785; }
                else if (In == "gallon/minute") { centimeter3hour = input * 227100; }
                else if (In == "gallon/second") { centimeter3hour = input * 13630000; }
                else if (In == "liter/day") { centimeter3hour = input * 41.667; }
                else if (In == "liter/hour") { centimeter3hour = input * 1000; }
                else if (In == "liter/minute") { centimeter3hour = input * 60000; }
                else if (In == "liter/second") { centimeter3hour = input * 3600000; }
                else if (In == "meter^3/day") { centimeter3hour = input * 41670; }
                else if (In == "meter^3/hour") { centimeter3hour = input * 1000000; }
                else if (In == "meter^3/minute") { centimeter3hour = input * 60000000; }
                else if (In == "meter^3/second") { centimeter3hour = input * 3600000000; }
                else if (In == "milliliter/hour") { centimeter3hour = input; }
                else if (In == "milliliter/minute") { centimeter3hour = input * 60; }
                else if (In == "milliliter/second") { centimeter3hour = input * 3600; }
                else if (In == "ounce (UK)/hour") { centimeter3hour = input * 28.4130784263; }
                else if (In == "ounce (UK)/minute") { centimeter3hour = input * 1704.78451183; }
                else if (In == "ounce (UK)/second") { centimeter3hour = input * 102287.067222; }
                else if (In == "ounce/hour") { centimeter3hour = input * 29.574; }
                else if (In == "ounce/minute") { centimeter3hour = input * 1774; }
                else if (In == "ounce/second") { centimeter3hour = input * 106500; }
                else if (In == "yard^3/hour") { centimeter3hour = input * 764600; }
                else if (In == "yard^3/minute") { centimeter3hour = input * 45870000; }
                else if (In == "yard^3/second") { centimeter3hour = input * 2752000000; }

                if (Out == "centimeter^3/hour") { return centimeter3hour; }
                else if (Out == "centimeter^3/minute") { return centimeter3hour / 60; }
                else if (Out == "centimeter^3/second") { return centimeter3hour / 3600; }
                else if (Out == "foot^3/hour") { return centimeter3hour / 28320; }
                else if (Out == "foot^3/minute") { return centimeter3hour / 1699000; }
                else if (Out == "foot^3/second") { return centimeter3hour / 101900000; }
                else if (Out == "gallon (UK)/day") { return centimeter3hour / 189.420486962; }
                else if (Out == "gallon (UK)/hour") { return centimeter3hour / 4546.09099819; }
                else if (Out == "gallon (UK)/minute") { return centimeter3hour / 272765.484692; }
                else if (Out == "gallon (UK)/second") { return centimeter3hour / 16365931.76; }
                else if (Out == "gallon/day") { return centimeter3hour / 157.7; }
                else if (Out == "gallon/hour") { return centimeter3hour / 3785; }
                else if (Out == "gallon/minute") { return centimeter3hour / 227100; }
                else if (Out == "gallon/second") { return centimeter3hour / 13630000; }
                else if (Out == "liter/day") { return centimeter3hour / 41.667; }
                else if (Out == "liter/hour") { return centimeter3hour / 1000; }
                else if (Out == "liter/minute") { return centimeter3hour / 60000; }
                else if (Out == "liter/second") { return centimeter3hour / 3600000; }
                else if (Out == "meter^3/day") { return centimeter3hour / 41670; }
                else if (Out == "meter^3/hour") { return centimeter3hour / 1000000; }
                else if (Out == "meter^3/minute") { return centimeter3hour / 60000000; }
                else if (Out == "meter^3/second") { return centimeter3hour / 3600000000;}
                else if (Out == "milliliter/hour") { return centimeter3hour; }
                else if (Out == "milliliter/minute") { return centimeter3hour / 60; }
                else if (Out == "milliliter/second") { return centimeter3hour / 3600; }
                else if (Out == "ounce (UK)/hour") { return centimeter3hour / 28.4130784263; }
                else if (Out == "ounce (UK)/minute") { return centimeter3hour / 1704.78451183; }
                else if (Out == "ounce (UK)/second") { return centimeter3hour / 102287.067222; }
                else if (Out == "ounce/hour") { return centimeter3hour / 29.574; }
                else if (Out == "ounce/minute") { return centimeter3hour / 1774; }
                else if (Out == "ounce/second") { return centimeter3hour / 106500; }
                else if (Out == "yard^3/hour") { return centimeter3hour / 764600; }
                else if (Out == "yard^3/minute") { return centimeter3hour / 45870000; }
                else if (Out == "yard^3/second") { return centimeter3hour / 2752000000; }
            }
            else if (convertType == "Force")
            {
                double dyne = input;

                if (In == "gram force") { dyne = input * 980.665204822; }
                else if (In == "kilogram force") { dyne = input * 980700; }
                else if (In == "kilonewton") { dyne = input * 100000000; }
                else if (In == "milinewton") { dyne = input * 100; }
                else if (In == "newton") { dyne = input * 100000; }
                else if (In == "ounce-force (ozf)") { dyne = input * 27801.3857879; }
                else if (In == "pound-force (lbf)") { dyne = input * 444822.246806; }

                if (Out == "dyne") { return dyne; }
                else if (Out == "gram force") { return dyne / 980.665204822; }
                else if (Out == "kilogram force") { return dyne / 980700; }
                else if (Out == "kilonewton") { return dyne / 100000000; }
                else if (Out == "milinewton") { return dyne / 100; }
                else if (Out == "newton") { return dyne / 100000; }
                else if (Out == "ounce-force (ozf)") { return dyne / 27801.3857879; }
                else if (Out == "pound-force (lbf)") { return dyne / 444822.246806; }
            }

            else if (convertType == "Light")
            {
                double flame = input;

                if (In == "foot-candles") { flame = input / 4; }
                else if (In == "lux") { flame = input / 43.05564; }
                else if (In == "meter-candles") { flame = input / 43.05564; }

                if (Out == "flame") { return flame; }
                else if (Out == "foot-candles") { return flame * 4; }
                else if (Out == "lux") { return flame * 43.05564; }
                else if (Out == "meter-candles") { return flame * 43.05564; }
            }

            else if (convertType == "Mass")
            {
                double kilogram = input;

                if (In == "carat") { kilogram = input / 5000; }
                else if (In == "grain (gr)") { kilogram = input / 15430; }
                else if (In == "gram (g)") { kilogram = input / 1000; }
                else if (In == "megagram (Mg)") { kilogram = input * 1000; }
                else if (In == "microgram (μg)") { kilogram = input / 1000000000; }
                else if (In == "miligram (mg)") { kilogram = input / 1000000; }
                else if (In == "ounce (avdp) (oz)") { kilogram = input / 35.27396194958; }
                else if (In == "ounce (troy) (ozt)") { kilogram = input / 32.1505; }
                else if (In == "pennyweight") { kilogram = input / 643; }
                else if (In == "pound (advp) (lb)") { kilogram = input / 2.20462; }
                else if (In == "pound (troy)") { kilogram = input / 2.679209; }
                else if (In == "stone") { kilogram = input / 0.1574728; }
                else if (In == "ton (long)") { kilogram = input / 0.0009842; }
                else if (In == "ton (short) (tn)") { kilogram = input / 0.0011023; }
                else if (In == "tonne (metric ton) (t)") { kilogram = input / 0.001; }

                if (Out == "kilogram (kg)") { return kilogram; }
                else if (Out == "carat") { return kilogram * 5000; }
                else if (Out == "grain (gr)") { return kilogram * 15430; }
                else if (Out == "gram (g)") { return kilogram * 1000; }
                else if (Out == "megagram (Mg)") { return kilogram / 1000; }
                else if (Out == "microgram (μg)") { return kilogram * 1000000000; }
                else if (Out == "miligram (mg)") { return kilogram * 1000000; }
                else if (Out == "ounce (avdp) (oz)") { return kilogram * 35.27396194958; }
                else if (Out == "ounce (troy) (ozt)") { return kilogram * 32.1505; }
                else if (Out == "pennyweight") { return kilogram * 643; }
                else if (Out == "pound (advp) (lb)") { return kilogram * 2.20462; }
                else if (Out == "pound (troy)") { return kilogram * 2.679209; }
                else if (Out == "stone") { return kilogram * 0.1574728; }
                else if (Out == "ton (long)") { return kilogram * 0.0009842; }
                else if (Out == "ton (short) (tn)") { return kilogram * 0.0011023; }
                else if (Out == "tonne (metric ton) (t)") { return kilogram * 0.001; }
            }

            else if (convertType == "Power")
            {
                double watt = input;

                if (In == "BTU/hour") { watt = input / 3.415179; }
                else if (In == "BTU/minute") { watt = input / 0.05691965; }
                else if (In == "BTU/second") { watt = input / 0.0009486608; }
                else if (In == "calorie/second") { watt = input / 0.2390585; }
                else if (In == "horsepower") { watt = input / 0.001341022; }
                else if (In == "kilowatt") { watt = input / 0.001; }
                else if (In == "megawatt") { watt = input / 0.000001; }
                else if (In == "pound-feet/minute") { watt = input / 44.25373; }
                else if (In == "pound-fee/second") { watt = input / 0.7375621; }

                if (Out == "watt") { return watt; }
                else if (Out == "BTU/hour") { return watt * 3.415179; }
                else if (Out == "BTU/minute") { return watt * 0.05691965; }
                else if (Out == "BTU/second") { return watt * 0.0009486608; }
                else if (Out == "calorie/second") { return watt * 0.2390585; }
                else if (Out == "horsepower") { return watt * 0.001341022; }
                else if (Out == "kilowatt") { return watt * 0.001; }
                else if (Out == "megawatt") { return watt * 0.000001; }
                else if (Out == "pound-feet/minute") { return watt * 44.25373; }
                else if (Out == "pound-fee/second") { return watt * 0.7375621; }
            }
            else if (convertType == "Pressure")
            {
                double atmosphere = input;

                if (In == "bar") { atmosphere = input / 1.01325; ; }
                else if (In == "centimeters of mercury") { atmosphere = input / 76; ; }
                else if (In == "dyne/centimeter^2") { atmosphere = input / 1013250; ; }
                else if (In == "inches of mercury") { atmosphere = input / 29.92126; ; }
                else if (In == "kilogram/centimeter^2") { atmosphere = input / 1.033227; ; }
                else if (In == "kilogram/meter^2") { atmosphere = input / 10332.27; ; }
                else if (In == "kilopascal") { atmosphere = input / 101.325; ; }
                else if (In == "megapascal") { atmosphere = input / 0.101325; ; }
                else if (In == "microbar") { atmosphere = input / 1013250; ; }
                else if (In == "milibar") { atmosphere = input / 1013.25; ; }
                else if (In == "milimeters of mercury") { atmosphere = input / 760; ; }
                else if (In == "pascal") { atmosphere = input / 101325; ; }
                else if (In == "pound/foot^2") { atmosphere = input / 2116.217; ; }
                else if (In == "pound/inch^2") { atmosphere = input / 14.69595; ; }
                else if (In == "PSI") { atmosphere = input / 14.69595; ; }
                else if (In == "ton/foot^2") { atmosphere = input / 1.058108; ; }
                else if (In == "ton/inch^2") { atmosphere = input / 0.007347974; ; }
                else if (In == "torr") { atmosphere = input / 760; ; }

                if (Out == "atmosphere") { return atmosphere; }
                else if (Out == "bar") { return atmosphere * 1.01325; }
                else if (Out == "centimeters of mercury") { return atmosphere * 76; }
                else if (Out == "dyne/centimeter^2") { return atmosphere * 1013250; }
                else if (Out == "inches of mercury") { return atmosphere * 29.92126; }
                else if (Out == "kilogram/centimeter^2") { return atmosphere * 1.033227; }
                else if (Out == "kilogram/meter^2") { return atmosphere * 10332.27; }
                else if (Out == "kilopascal") { return atmosphere * 101.325; }
                else if (Out == "megapascal") { return atmosphere * 0.101325; }
                else if (Out == "microbar") { return atmosphere * 1013250; }
                else if (Out == "milibar") { return atmosphere * 1013.25; }
                else if (Out == "milimeters of mercury") { return atmosphere * 760; }
                else if (Out == "pascal") { return atmosphere * 101325; }
                else if (Out == "pound/foot^2") { return atmosphere * 2116.217; }
                else if (Out == "pound/inch^2") { return atmosphere * 14.69595; }
                else if (Out == "PSI") { return atmosphere * 14.69595; }
                else if (Out == "ton/foot^2") { return atmosphere * 1.058108; }
                else if (Out == "ton/inch^2") { return atmosphere * 0.007347974; }
                else if (Out == "torr") { return atmosphere * 760; }
            }
            else if (convertType == "Speed")
            {
                double centimeterHour = input;

                if (In == "C") { centimeterHour = input / 0.000000000000009265669; }
                else if (In == "centimeter/minute") { centimeterHour = input * 60; }
                else if (In == "centimeter/second") { centimeterHour = input * 3600; }
                else if (In == "foot/hour") { centimeterHour = input * 30.48; }
                else if (In == "foot/minute") { centimeterHour = input * 1829; }
                else if (In == "foot/second") { centimeterHour = input * 109700; }
                else if (In == "kilometer/hour") { centimeterHour = input * 100000; }
                else if (In == "kilometer/minute") { centimeterHour = input * 6000000; }
                else if (In == "kilometer/second") { centimeterHour = input * 360000000; }
                else if (In == "knot") { centimeterHour = input * 185200; }
                else if (In == "mach") { centimeterHour = input * 123500000; }
                else if (In == "meter/hour") { centimeterHour = input * 100; }
                else if (In == "meter/minute") { centimeterHour = input * 6000; }
                else if (In == "meter/second") { centimeterHour = input * 360000; }
                else if (In == "mile/hour") { centimeterHour = input * 160900; }
                else if (In == "mile/minute") { centimeterHour = input * 9656000; }
                else if (In == "mile/second") { centimeterHour = input * 579400000; }

                if (Out == "centimeter/hour") { return centimeterHour; }
                else if (Out == "C") { return centimeterHour * 0.000000000000009265669; }
                else if (Out == "centimeter/minute") { return centimeterHour / 60; }
                else if (Out == "centimeter/second") { return centimeterHour / 3600; }
                else if (Out == "foot/hour") { return centimeterHour / 30.48; }
                else if (Out == "foot/minute") { return centimeterHour / 1829; }
                else if (Out == "foot/second") { return centimeterHour / 109700; }
                else if (Out == "kilometer/hour") { return centimeterHour / 100000; }
                else if (Out == "kilometer/minute") { return centimeterHour / 6000000; }
                else if (Out == "kilometer/second") { return centimeterHour / 360000000; }
                else if (Out == "knot") { return centimeterHour / 185200; }
                else if (Out == "mach") { return centimeterHour / 123500000; }
                else if (Out == "meter/hour") { return centimeterHour / 100; }
                else if (Out == "meter/minute") { return centimeterHour / 6000; }
                else if (Out == "meter/second") { return centimeterHour / 360000; }
                else if (Out == "mile/hour") { return centimeterHour / 160900; }
                else if (Out == "mile/minute") { return centimeterHour / 9656000; }
                else if (Out == "mile/second") { return centimeterHour / 579400000; }
            }
            else if (convertType == "Temperature")
            {
                double Ctemp = input;
                if (In == "°C") { Ctemp = input; }
                else if (In == "°F") { Ctemp = (input - 32) / 1.8; }
                else if (In == "°K") { Ctemp = input - 273.15; }
                else if (In == "°R") { Ctemp = (input - 491.67) / 1.8; }

                if (Out == "°C") { return Ctemp; }
                else if (Out == "°F") { return (Ctemp * 1.8) + 32; }
                else if (Out == "°K") { return Ctemp + 273.15; }
                else if (Out == "°R") { return (Ctemp * 1.8) + 491.67; }

            }
            else if (convertType == "Time")
            {
                double century = input;

                if (In == "day") { century = input / 36500; }
                else if (In == "decade") { century = input / 10; }
                else if (In == "fortnight") { century = input / 2607; }
                else if (In == "hour") { century = input / 876000; }
                else if (In == "leap-year") { century = input / 99.72678; }
                else if (In == "millennium") { century = input * 10; }
                else if (In == "milisecond") { century = input / 3154000000000; }
                else if (In == "minute (')") { century = input / 52560000; }
                else if (In == "month (30 day)") { century = input / 1200; }
                else if (In == "nanosecond") { century = input / 3154000000000000000; }
                else if (In == "second ('')") { century = input / 3154000000; }
                else if (In == "week") { century = input / 5214; }
                else if (In == "year") { century = input / 100; }

                if (Out == "century") { return century; }
                else if (Out == "day") { return century * 36500; }
                else if (Out == "decade") { return century * 10; }
                else if (Out == "fortnight") { return century * 2607; }
                else if (Out == "hour") { return century * 876000; }
                else if (Out == "leap-year") { return century * 99.72678; }
                else if (Out == "millennium") { return century / 10; }
                else if (Out == "milisecond") { return century * 3154000000000; }
                else if (Out == "minute (')") { return century * 52560000; }
                else if (Out == "month (30 day)") { return century * 1200; }
                else if (Out == "nanosecond") { return century * 3154000000000000000; }
                else if (Out == "second ('')") { return century * 3154000000; }
                else if (Out == "week") { return century * 5214; }
                else if (Out == "year") { return century * 100; }
            }
            else if (convertType == "Torque")
            {
                double dynecentimeter = input;

                if (In == "gram-force centimeter (gf • cm)") { dynecentimeter = input * 980.665; }
                else if (In == "kilogram-force meter (kgf • m)") { dynecentimeter = input * 98066500; }
                else if (In == "kilonewton meter (kN • m)") { dynecentimeter = input * 10000000000; }
                else if (In == "kilopond meter (kp • m)") { dynecentimeter = input * 98066500; }
                else if (In == "meganewton meter (MN • m)") { dynecentimeter = input * 10000000000000; }
                else if (In == "micronewton meter (μN • m)") { dynecentimeter = input * 10; }
                else if (In == "milinewton meter (mN • m)") { dynecentimeter = input * 10000; }
                else if (In == "newton meter (N • m)") { dynecentimeter = input * 10000000; }
                else if (In == "ounce-force foot (ozf • ft)") { dynecentimeter = input * 847387.9; }
                else if (In == "ounce-force inch (ozf • in)") { dynecentimeter = input * 70615.5; }
                else if (In == "pound-force foot (lbf • ft)") { dynecentimeter = input * 13558200; }
                else if (In == "pound-force inch (lbf • in)") { dynecentimeter = input * 1129848; }

                if (Out == "dyne centimeter (dyn • cm)") { return dynecentimeter; }
                else if (Out == "gram-force centimeter (gf • cm)") { return dynecentimeter / 980.665; }
                else if (Out == "kilogram-force meter (kgf • m)") { return dynecentimeter / 98066500; }
                else if (Out == "kilonewton meter (kN • m)") { return dynecentimeter / 10000000000; }
                else if (Out == "kilopond meter (kp • m)") { return dynecentimeter / 98066500; }
                else if (Out == "meganewton meter (MN • m)") { return dynecentimeter / 10000000000000; }
                else if (Out == "micronewton meter (μN • m)") { return dynecentimeter / 10; }
                else if (Out == "milinewton meter (mN • m)") { return dynecentimeter / 10000; }
                else if (Out == "newton meter (N • m)") { return dynecentimeter / 10000000; }
                else if (Out == "ounce-force foot (ozf • ft)") { return dynecentimeter / 847387.9; }
                else if (Out == "ounce-force inch (ozf • in)") { return dynecentimeter / 70615.5; }
                else if (Out == "pound-force foot (lbf • ft)") { return dynecentimeter / 13558200; }
                else if (Out == "pound-force inch (lbf • in)") { return dynecentimeter / 1129848; }
            }
            else if (convertType == "Volume")
            {
            double liter = input;


            if (In == "CC") { liter = input / 1000; }
            else if (In == "cubic centimeter") { liter = input / 1000; }
            else if (In == "cubic foot") { liter = input / 0.03531467; }
            else if (In == "cubic inch") { liter = input / 61.02374; }
            else if (In == "cubic meter") { liter = input / 0.001; }
            else if (In == "cubic yard") { liter = input / 0.001307951; }
            else if (In == "cup") { liter = input / 4.226753; }
            else if (In == "dram") { liter = input / 270.5104; }
            else if (In == "drop") { liter = input / 15419.63; }
            else if (In == "gallon") { liter = input / 0.2641721; }
            else if (In == "gallon (UK)") { liter = input / 0.2199692; }
            else if (In == "milliliter") { liter = input / 1000; }
            else if (In == "minim (US)") { liter = input / 16230.73; }
            else if (In == "ounce (oz)") { liter = input / 33.81402; }
            else if (In == "ounce (oz) (UK)") { liter = input / 35.19506; }
            else if (In == "pint (pt)") { liter = input / 2.113376; }
            else if (In == "pint (pt) (UK)") { liter = input / 1.759754; }
            else if (In == "quart") { liter = input / 1.056688; }
            else if (In == "tablespoon") { liter = input / 67.62805; }
            else if (In == "teaspoon") { liter = input / 202.8841; }

            if (Out == "liter") { return liter; }
            else if (Out == "CC") { return liter * 1000; }
            else if (Out == "cubic centimeter") { return liter * 1000; }
            else if (Out == "cubic foot") { return liter * 0.03531467; }
            else if (Out == "cubic inch") { return liter * 61.02374; }
            else if (Out == "cubic meter") { return liter * 0.001; }
            else if (Out == "cubic yard") { return liter * 0.001307951; }
            else if (Out == "cup") { return liter * 4.226753; }
            else if (Out == "dram") { return liter * 270.5104; }
            else if (Out == "drop") { return liter * 15419.63; }
            else if (Out == "gallon") { return liter * 0.2641721; }
            else if (Out == "gallon (UK)") { return liter * 0.2199692; }
            else if (Out == "milliliter") { return liter * 1000; }
            else if (Out == "minim (US)") { return liter * 16230.73; }
            else if (Out == "ounce (oz)") { return liter * 33.81402; }
            else if (Out == "ounce (oz) (UK)") { return liter * 35.19506; }
            else if (Out == "pint (pt)") { return liter * 2.113376; }
            else if (Out == "pint (pt) (UK)") { return liter * 1.759754; }
            else if (Out == "quart") { return liter * 1.056688; }
            else if (Out == "tablespoon") { return liter * 67.62805; }
            else if (Out == "teaspoon") { return liter * 202.8841; }
            }
            return 1.6948;
        }

        // all of the button functions


    }
    public class ApplicationVariables
    {
        public int[] Acceleration = new int[] { 0, 0 };
        public int[] AmtOfSubstance = new int[] { 0, 0 };
        public int[] Angle = new int[] { 0, 0 };
        public int[] Area = new int[] { 0, 0 };
        public int[] Computer = new int[] { 0, 0 };
        public int[] Concentration = new int[] { 0, 0 };
        public int[] Density = new int[] { 0, 0 };
        public int[] Distance = new int[] { 0, 0 };
        public int[] Energy = new int[] { 0, 0 };
        public int[] Flow = new int[] { 0, 0 };
        public int[] Force = new int[] { 0, 0 };
        public int[] Light = new int[] { 0, 0 };
        public int[] Mass = new int[] { 0, 0 };
        public int[] Power = new int[] { 0, 0 };
        public int[] Pressure = new int[] { 0, 0 };
        public int[] Speed = new int[] { 0, 0 };
        public int[] Temperature = new int[] { 0, 0 };
        public int[] Time = new int[] { 0, 0 };
        public int[] Torque = new int[] { 0, 0 };
        public int[] Volume = new int[] { 0, 0 };
    }
}
