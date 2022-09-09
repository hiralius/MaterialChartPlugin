using Grabacr07.KanColleWrapper;
using Livet;
using Livet.EventListeners;
using MetroTrilithon.Mvvm;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MaterialChartPlugin.Models
{
	public class SplitData
	{
		public DateTime StartDate;

		public int StartFuel;
		public int StartAmmunition;
		public int StartSteel;
		public int StartBauxite;
		public int StartRepairTool;
	}

	public class SplitInfo : NotificationObject
	{
		private static readonly string localDirectoryPath =
			Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
		private static readonly string saveFileBase = "materialconfig";
		private static string ConfigFilePath;

		private int StartFuel;
		private int StartAmmunition;
		private int StartSteel;
		private int StartBauxite;
		private int StartRepairTool;

		private readonly XmlSerializer serializer = new XmlSerializer(typeof(SplitData));

		private DateTime _StartDate;
		private DateTime StartDate { get => _StartDate; set => RaisePropertyChangedIfSet(ref _StartDate, value, nameof(StartDateString)); }

		public string StartDateString 
		{ 
			get => _StartDate.ToString();
		}

		private int _Fuel;
		public int Fuel { get => _Fuel; set => RaisePropertyChangedIfSet(ref _Fuel, value); }

		private int _Ammunition;
		public int Ammunition { get => _Ammunition; set => RaisePropertyChangedIfSet(ref _Ammunition, value); }

		private int _Steel;
		public int Steel { get => _Steel; set => RaisePropertyChangedIfSet(ref _Steel, value); }

		private int _Baxite;
		public int Bauxite { get => _Baxite; set => RaisePropertyChangedIfSet(ref _Baxite, value); }

		private int _RepairTool;
		public int RepairTool { get => _RepairTool; set => RaisePropertyChangedIfSet(ref _RepairTool, value); }


		private readonly MaterialManager materialManager;

		public SplitInfo(MaterialManager m)
		{
			var saveFileName = $"{saveFileBase}_{KanColleClient.Current.Homeport.Admiral.MemberId}";
			ConfigFilePath = Path.Combine(localDirectoryPath, saveFileName + ".xml");

			materialManager = m;
			Load();
			m.PropertyChanged += Changed;
		}

		public void Reset()
		{
			StartDate = DateTime.Now;
			StartFuel = materialManager.Fuel;
			StartAmmunition = materialManager.Ammunition;
			StartSteel = materialManager.Steel;
			StartBauxite = materialManager.Bauxite;
			StartRepairTool = materialManager.RepairTool;

			Fuel = 0;
			Ammunition = 0;
			Steel = 0;
			Bauxite = 0;
			RepairTool = 0;

			Save();
			RaisePropertyChanged();
		}

		private void Changed(object sender, PropertyChangedEventArgs e)
		{
			switch(e.PropertyName)
			{
				case "Fuel":
					Fuel = materialManager.Fuel - StartFuel;
					break;

				case "Ammunition":
					Ammunition = materialManager.Ammunition - StartAmmunition;
					break;

				case "Steel":
					Steel = materialManager.Steel - StartSteel;
					break;

				case "Bauxite":
					Bauxite = materialManager.Bauxite - StartBauxite;
					break;

				case "RepairTool":
					RepairTool = materialManager.RepairTool - StartRepairTool;
					break;
			}
		}

		private void Load()
		{
			if (!File.Exists(ConfigFilePath))
			{
				Reset();
				return;
			}

			SplitData config;
			using (var sr = File.OpenRead(ConfigFilePath))
			{
				config = serializer.Deserialize(sr) as SplitData;
			}
			StartDate = config.StartDate;

			StartFuel = config.StartFuel;
			Fuel = materialManager.Fuel - StartFuel;

			StartAmmunition = config.StartAmmunition;
			Ammunition = materialManager.Ammunition - StartAmmunition;

			StartSteel = config.StartSteel;
			Steel = materialManager.Steel - StartSteel;

			StartBauxite = config.StartBauxite;
			Bauxite = materialManager.Bauxite - StartBauxite;

			StartRepairTool = config.StartRepairTool;
			RepairTool = materialManager.RepairTool - StartRepairTool;
		}

		private void Save()
		{
			var config = new SplitData();
			config.StartDate = StartDate;
			config.StartFuel = StartFuel;
			config.StartAmmunition = StartAmmunition;
			config.StartSteel = StartSteel;
			config.StartBauxite = StartBauxite;
			config.StartRepairTool = StartRepairTool;

			using( var sw = new FileStream(ConfigFilePath, FileMode.Create, FileAccess.Write))
			{
				serializer.Serialize(sw, config);
			}
		}
	}
}
