using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Livet;
using Livet.EventListeners;
using MetroTrilithon.Mvvm;
using MaterialChartPlugin.Models;
using MaterialChartPlugin.Models.Settings;
using MaterialChartPlugin.Models.Utilities;
using System.Reactive.Linq;
using System.Windows;
using Microsoft.Win32;
using MaterialChartPlugin.Properties;
using System.ComponentModel;

namespace MaterialChartPlugin.ViewModels
{
	public class ToolViewModel : ViewModel
    {
        private MaterialChartPlugin plugin;

        public MaterialManager MaterialManager { get; }

        public int Fuel => MaterialManager.Fuel;

        public int Ammunition => MaterialManager.Ammunition;

        public int Steel => MaterialManager.Steel;

        public int Bauxite => MaterialManager.Bauxite;

        public int RepairTool => MaterialManager.RepairTool;

        public int DevelopmentMaterials => MaterialManager.DevelopmentMaterials;

        public int ImprovementMaterials => MaterialManager.ImprovementMaterials;

        public int InstantBuildMaterials => MaterialManager.InstantBuildMaterials;


        #region FuelSeries変更通知プロパティ
        private ObservableCollection<ChartPoint> _FuelSeries = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> FuelSeries
        {
            get
            { return _FuelSeries; }
            set
            {
                if (_FuelSeries == value)
                    return;
                _FuelSeries = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region AmmunitionSeries変更通知プロパティ
        private ObservableCollection<ChartPoint> _AmmunitionSeries = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> AmmunitionSeries
        {
            get
            { return _AmmunitionSeries; }
            set
            {
                if (_AmmunitionSeries == value)
                    return;
                _AmmunitionSeries = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region SteelSeries変更通知プロパティ
        private ObservableCollection<ChartPoint> _SteelSeries = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> SteelSeries
        {
            get
            { return _SteelSeries; }
            set
            {
                if (_SteelSeries == value)
                    return;
                _SteelSeries = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region BauxiteSeries変更通知プロパティ
        private ObservableCollection<ChartPoint> _BauxiteSeries = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> BauxiteSeries
        {
            get
            { return _BauxiteSeries; }
            set
            {
                if (_BauxiteSeries == value)
                    return;
                _BauxiteSeries = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region RepairToolSeries変更通知プロパティ
        private ObservableCollection<ChartPoint> _RepairToolSeries = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> RepairToolSeries
        {
            get
            { return _RepairToolSeries; }
            set
            {
                if (_RepairToolSeries == value)
                    return;
                _RepairToolSeries = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ImprovementToolSeries変更通知プロパティ
        private ObservableCollection<ChartPoint> _ImprovementToolSeries = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> ImprovementToolSeries
        {
            get
            { return _ImprovementToolSeries; }
            set
            {
                if (_ImprovementToolSeries == value)
                    return;
                _ImprovementToolSeries = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region DevelopmentToolSeries変更通知プロパティ
        private ObservableCollection<ChartPoint> _DevelopmentToolSeries = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> DevelopmentToolSeries
        {
            get
            { return _DevelopmentToolSeries; }
            set
            {
                if (_DevelopmentToolSeries == value)
                    return;
                _DevelopmentToolSeries = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region InstantBuildToolSeries変更通知プロパティ
        private ObservableCollection<ChartPoint> _InstantBuildToolSeries = new ObservableCollection<ChartPoint>();

        public ObservableCollection<ChartPoint> InstantBuildToolSeries
        {
            get
            { return _InstantBuildToolSeries; }
            set
            {
                if (_InstantBuildToolSeries == value)
                    return;
                _InstantBuildToolSeries = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region StorableLimitSeries変更通知プロパティ
        private ObservableCollection<ChartPoint> _StorableLimitSeries;

        public ObservableCollection<ChartPoint> StorableLimitSeries
        {
            get
            { return _StorableLimitSeries; }
            set
            {
                if (_StorableLimitSeries == value)
                    return;
                _StorableLimitSeries = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region XMin変更通知プロパティ
        private DateTime _XMin = DateTime.Now - TimeSpan.FromDays(1);

        public DateTime XMin
        {
            get
            { return _XMin; }
            set
            {
                if (_XMin == value)
                    return;
                _XMin = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region XMax変更通知プロパティ
        private DateTime _XMax = DateTime.Now;

        public DateTime XMax
        {
            get
            { return _XMax; }
            set
            {
                if (_XMax == value)
                    return;
                _XMax = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region YMax1変更通知プロパティ
        private double _YMax1 = 1000;

        public double YMax1
        {
            get
            { return _YMax1; }
            set
            {
                if (_YMax1 == value)
                    return;
                _YMax1 = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region YMax2変更通知プロパティ
        private double _YMax2 = 100;

        public double YMax2
        {
            get
            { return _YMax2; }
            set
            {
                if (_YMax2 == value)
                    return;
                _YMax2 = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region YMin1変更通知プロパティ
        private double _YMin1 = 0;

        public double YMin1
        {
            get
            { return _YMin1; }
            set
            {
                if (_YMin1 == value)
                    return;
                _YMin1 = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region YMin1変更通知プロパティ
        private double _YMin2 = 0;

        public double YMin2
        {
            get
            {
                return _YMin2;
            }
            set
            {
                if (_YMin2 == value)
                    return;
                _YMin2 = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IsYMinFixedAtZero変更通知プロパティ
        private Boolean _IsYMinFixedAtZero = MaterialChartSettings.Default.IsYMinFixedAtZero;

        public Boolean IsYMinFixedAtZero
        {
            get
            {
                return _IsYMinFixedAtZero;
            }
            set
            {
                _IsYMinFixedAtZero = value;
                MaterialChartSettings.Default.IsYMinFixedAtZero = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IsFuelChartEnable変更通知プロパティ
        private Boolean _IsFuelChartEnable = MaterialChartSettings.Default.IsFuelChartEnable;
        public Boolean IsFuelChartEnable
        {
            get
            {
                return _IsFuelChartEnable;
            }
            set
            {
                _IsFuelChartEnable = value;
                MaterialChartSettings.Default.IsFuelChartEnable = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(this.IsFuelChartVisible));
            }
        }
        #endregion

        #region IsAmmunitionChartEnable変更通知プロパティ
        private Boolean _IsAmmunitionChartEnable = MaterialChartSettings.Default.IsAmmunitionChartEnable;
        public Boolean IsAmmunitionChartEnable
        {
            get
            {
                return _IsAmmunitionChartEnable;
            }
            set
            {
                _IsAmmunitionChartEnable = value;
                MaterialChartSettings.Default.IsAmmunitionChartEnable = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(this.IsAmmunitionChartVisible));
            }
        }
        #endregion

        #region IsSteelChartEnable変更通知プロパティ
        private Boolean _IsSteelChartEnable = MaterialChartSettings.Default.IsSteelChartEnable;
        public Boolean IsSteelChartEnable
        {
            get
            {
                return _IsSteelChartEnable;
            }
            set
            {
                _IsSteelChartEnable = value;
                MaterialChartSettings.Default.IsSteelChartEnable = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(this.IsSteelChartVisible));
            }
        }
        #endregion

        #region IsBauxiteChartEnable変更通知プロパティ
        private Boolean _IsBauxiteChartEnable = MaterialChartSettings.Default.IsBauxiteChartEnable;
        public Boolean IsBauxiteChartEnable
        {
            get
            {
                return _IsBauxiteChartEnable;
            }
            set
            {
                _IsBauxiteChartEnable = value;
                MaterialChartSettings.Default.IsBauxiteChartEnable = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(this.IsBauxiteChartVisible));
            }
        }
        #endregion

        #region IsRepairToolChartEnable 変更通知プロパティ
        private Boolean _IsRepairToolChartEnable = MaterialChartSettings.Default.IsRepairToolChartEnable;
        public Boolean IsRepairToolChartEnable
        {
            get
            {
                return _IsRepairToolChartEnable;
            }
            set
            {
                _IsRepairToolChartEnable = value;
                MaterialChartSettings.Default.IsRepairToolChartEnable = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(this.IsRepairToolChartVisible));
            }
        }
        #endregion

        #region IsImprovementToolChartEnable 変更通知プロパティ
        private Boolean _IsImprovementToolChartEnable = MaterialChartSettings.Default.IsImprovementToolChartEnable;
        public Boolean IsImprovementToolChartEnable
        {
            get
            {
                return _IsImprovementToolChartEnable;
            }
            set
            {
                _IsImprovementToolChartEnable = value;
                MaterialChartSettings.Default.IsImprovementToolChartEnable = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(this.IsImprovementToolChartVisible));
            }
        }
        #endregion

        #region IsDevelopmentToolChartEnable 変更通知プロパティ
        private Boolean _IsDevelopmentToolChartEnable = MaterialChartSettings.Default.IsDevelopmentToolChartEnable;
        public Boolean IsDevelopmentToolChartEnable
        {
            get
            {
                return _IsDevelopmentToolChartEnable;
            }
            set
            {
                _IsDevelopmentToolChartEnable = value;
                MaterialChartSettings.Default.IsDevelopmentToolChartEnable = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(this.IsDevelopmentToolChartVisible));
            }
        }
        #endregion

        #region IsInstantBuildToolChartEnable 変更通知プロパティ
        private Boolean _IsInstantBuildToolChartEnable = MaterialChartSettings.Default.IsInstantBuildToolChartEnable;
        public Boolean IsInstantBuildToolChartEnable
        {
            get
            {
                return _IsInstantBuildToolChartEnable;
            }
            set
            {
                _IsInstantBuildToolChartEnable = value;
                MaterialChartSettings.Default.IsInstantBuildToolChartEnable = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(this.IsInstantBuildToolChartVisible));
            }
        }
        #endregion

        public Visibility IsFuelChartVisible => IsFuelChartEnable.IsVisible();

        public Visibility IsAmmunitionChartVisible => IsAmmunitionChartEnable.IsVisible();

        public Visibility IsSteelChartVisible => IsSteelChartEnable.IsVisible();
 
        public Visibility IsBauxiteChartVisible => IsBauxiteChartEnable.IsVisible();

        public Visibility IsRepairToolChartVisible => IsRepairToolChartEnable.IsVisible();

        public Visibility IsImprovementToolChartVisible => IsImprovementToolChartEnable.IsVisible();

        public Visibility IsDevelopmentToolChartVisible => IsDevelopmentToolChartEnable.IsVisible();

        public Visibility IsInstantBuildToolChartVisible => IsInstantBuildToolChartEnable.IsVisible();

        public DisplayedPeriod DisplayedPeriod => ChartSettings.DisplayedPeriod.Value;

        public IReadOnlyCollection<DisplayViewModel<DisplayedPeriod>> DisplayedPeriods { get; }

		public SplitInfo Split { get; private set; }

		private int mostMaterial = 0;

        private int minMaterial = 0;

        private int mostTool = 0;

        private int minTool = 0;

        PropertyChangedEventListener managerChangedListener;

        PropertyChangedEventListener logChangedListener;

        PropertyChangedEventListener viewSettingChangedListener;

        public ToolViewModel(MaterialChartPlugin plugin)
        {
            this.plugin = plugin;

            this.MaterialManager = new MaterialManager(plugin);

            this.DisplayedPeriods = new List<DisplayViewModel<DisplayedPeriod>>()
            {
                DisplayViewModel.Create(DisplayedPeriod.OneDay, "1日"),
                DisplayViewModel.Create(DisplayedPeriod.OneWeek, "1週間"),
                DisplayViewModel.Create(DisplayedPeriod.OneMonth, "1ヶ月"),
                DisplayViewModel.Create(DisplayedPeriod.ThreeMonths, "3ヶ月"),
                DisplayViewModel.Create(DisplayedPeriod.HalfYear, "半年"),
                DisplayViewModel.Create(DisplayedPeriod.OneYear, "1年"),
                DisplayViewModel.Create(DisplayedPeriod.ThreeYears, "3年")
            };

        }

        public async void Initialize()
        {
			await MaterialManager.Initialize();
			RefleshData();

			Split = new SplitInfo(MaterialManager);
			Split.PropertyChanged += Split_PropertyChanged;

			var history = MaterialManager.Log.History;

            // データ初期読み込み
            logChangedListener = new PropertyChangedEventListener(MaterialManager.Log)
                {
                    { nameof(MaterialManager.Log.HasLoaded), (_, __) =>
                        {
                            if (MaterialManager.Log.HasLoaded)
                                RefleshData();
                        }
                    }
                };

            // 資材データの通知設定
            managerChangedListener = new PropertyChangedEventListener(MaterialManager)
                    {
                        { nameof(MaterialManager.Fuel),  (_,__) => RaisePropertyChanged(nameof(Fuel)) },
                        { nameof(MaterialManager.Ammunition),  (_,__) => RaisePropertyChanged(nameof(Ammunition)) },
                        { nameof(MaterialManager.Steel),  (_,__) => RaisePropertyChanged(nameof(Steel)) },
                        { nameof(MaterialManager.Bauxite),  (_,__) => RaisePropertyChanged(nameof(Bauxite)) },
                        { nameof(MaterialManager.RepairTool),  (_,__) => RaisePropertyChanged(nameof(RepairTool)) },
                        { nameof(MaterialManager.ImprovementMaterials),  (_,__) => RaisePropertyChanged(nameof(ImprovementMaterials)) },
                        { nameof(MaterialManager.DevelopmentMaterials),  (_,__) => RaisePropertyChanged(nameof(DevelopmentMaterials)) },
                        { nameof(MaterialManager.InstantBuildMaterials),  (_,__) => RaisePropertyChanged(nameof(InstantBuildMaterials)) },
                        //{
                        //    // materialManagerの初期化が完了したら、DisplayedPeriodの変更時に更新を行うよう設定
                        //    nameof(materialManager.IsAvailable),
                        //    (_,__) => ChartSettings.DisplayedPeriod.Subscribe(___ =>
                        //        {
                        //            RefleshData();
                        //            RaisePropertyChanged(nameof(DisplayedPeriod));
                        //        }).AddTo(this)
                        //}
                    };

			// この段階でmaterialManagerの初期化は完了しているので、DisplayedPeriodの変更時に更新を行うよう設定
			ChartSettings.DisplayedPeriod.Subscribe(___ =>
			{
				if(MaterialManager.IsAvailable)
				{
					RefleshData();
					RaisePropertyChanged(nameof(DisplayedPeriod));
				}
			}).AddTo(this);

			// 表示設定変更の通知設定
			viewSettingChangedListener = new PropertyChangedEventListener(this)
			{
				{
					nameof(this.IsYMinFixedAtZero), (_, __) =>
					{
						if (MaterialManager.Log.HasLoaded)
								RefleshData();
					}
				},
				{
					nameof(this.IsFuelChartEnable), (_, __) =>
					{
						if (MaterialManager.Log.HasLoaded)
								RefleshData();
					}
				},
				{
					nameof(this.IsAmmunitionChartEnable), (_, __) =>
					{
						if (MaterialManager.Log.HasLoaded)
								RefleshData();
					}
				},
				{
					nameof(this.IsSteelChartEnable), (_, __) =>
					{
						if (MaterialManager.Log.HasLoaded)
								RefleshData();
					}
				},
				{
					nameof(this.IsBauxiteChartEnable), (_, __) =>
					{
						if (MaterialManager.Log.HasLoaded)
								RefleshData();
					}
				},
				{
					nameof(this.IsRepairToolChartEnable), (_, __) =>
					{
						if (MaterialManager.Log.HasLoaded)
								RefleshData();
					}
				},
				{
					nameof(this.IsImprovementToolChartEnable), (_, __) =>
					{
						if (MaterialManager.Log.HasLoaded)
								RefleshData();
					}
				},
				{
					nameof(this.IsDevelopmentToolChartEnable), (_, __) =>
					{
						if (MaterialManager.Log.HasLoaded)
								RefleshData();
					}
				},
				{
					nameof(this.IsInstantBuildToolChartEnable), (_, __) =>
					{
						if (MaterialManager.Log.HasLoaded)
								RefleshData();
					}
				}
            };

			// データ更新設定
			Observable.FromEvent<NotifyCollectionChangedEventHandler, NotifyCollectionChangedEventArgs>
                (h => (sender, e) => h(e), h => history.CollectionChanged += h, h => history.CollectionChanged -= h)
                .Where(_ => MaterialManager.Log.HasLoaded)
                .Throttle(TimeSpan.FromMilliseconds(10))
                .Subscribe(_ => UpdateData(history.Last())
				);
        }

		private void Split_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			RaisePropertyChanged();
		}

		/// <summary>
		/// グラフに新しいデータを追加します。
		/// </summary>
		/// <param name="newData"></param>
		public void UpdateData(TimeMaterialsPair newData)
        {
            var materialChartVisibleList = new[] { IsFuelChartEnable, IsAmmunitionChartEnable, IsSteelChartEnable, IsBauxiteChartEnable };
            var toolChartVisibleList = new[] { IsRepairToolChartEnable, IsImprovementToolChartEnable, IsDevelopmentToolChartEnable, IsInstantBuildToolChartEnable };

            SetXAxis(newData);
            SetMaterialYAxis(
                Math.Max(this.mostMaterial, newData.MostMaterial(materialChartVisibleList)),
                Math.Min(this.minMaterial, newData.MinMaterial(materialChartVisibleList)));
            SetToolYAxis(
                Math.Max(this.mostTool, newData.MostTool(toolChartVisibleList)),
                Math.Min(this.minTool, newData.MinTool(toolChartVisibleList)));
            AddChartData(newData);
        }

        /// <summary>
        /// グラフのデータをリフレッシュします。
        /// </summary>
        public void RefleshData()
        {
            // 描画すべきデータがなかったら何もしない
            if (MaterialManager.Log.History
                .Within(ChartSettings.DisplayedPeriod)
                .ThinOut(ChartSettings.DisplayedPeriod).Count() == 0)
                return;

            var neededData = MaterialManager.Log.History
                .Within(ChartSettings.DisplayedPeriod)
                .ThinOut(ChartSettings.DisplayedPeriod)
                .ToArray();

            var materialChartVisibleList = new[] { IsFuelChartEnable, IsAmmunitionChartEnable, IsSteelChartEnable, IsBauxiteChartEnable };
            var toolChartVisibleList = new[] { IsRepairToolChartEnable, IsImprovementToolChartEnable, IsDevelopmentToolChartEnable, IsInstantBuildToolChartEnable };

            SetXAxis(neededData[neededData.Length - 1]);
            SetMaterialYAxis(
                neededData.Max(p => p.MostMaterial(materialChartVisibleList)),
                neededData.Min(p => p.MinMaterial(materialChartVisibleList)));
            SetToolYAxis(
                neededData.Max(p => p.MostTool(toolChartVisibleList)),
                neededData.Min(p => p.MinTool(toolChartVisibleList)));
            RefleshChartData(neededData);
        }

        private void AddChartData(TimeMaterialsPair data)
        {
            Application.Current.Dispatcher.Invoke(
                () =>
                {
                    FuelSeries.Add(new ChartPoint(data.DateTime, data.Fuel));
                    AmmunitionSeries.Add(new ChartPoint(data.DateTime, data.Ammunition));
                    SteelSeries.Add(new ChartPoint(data.DateTime, data.Steel));
                    BauxiteSeries.Add(new ChartPoint(data.DateTime, data.Bauxite));
                    RepairToolSeries.Add(new ChartPoint(data.DateTime, data.RepairTool));
                    ImprovementToolSeries.Add(new ChartPoint(data.DateTime, data.ImprovementTool));
                    DevelopmentToolSeries.Add(new ChartPoint(data.DateTime, data.DevelopmentTool));
                    InstantBuildToolSeries.Add(new ChartPoint(data.DateTime, data.InstantBuildTool));
                });

            var currentDateTime = data.DateTime;

            var storableLimit = new ObservableCollection<ChartPoint>();
            storableLimit.Add(new ChartPoint(currentDateTime - ChartSettings.DisplayedPeriod.Value.ToTimeSpan(),
                MaterialManager.StorableMaterialLimit));
            storableLimit.Add(new ChartPoint(currentDateTime, MaterialManager.StorableMaterialLimit));
            this.StorableLimitSeries = storableLimit;
        }

        /// <summary>
        /// チャートにバインディングされたObservableCollectionのデータをリフレッシュします。
        /// </summary>
        /// <param name="neededData"></param>
        private void RefleshChartData(TimeMaterialsPair[] neededData)
        {
            var fuels = new ObservableCollection<ChartPoint>();
            var ammunitions = new ObservableCollection<ChartPoint>();
            var steels = new ObservableCollection<ChartPoint>();
            var bauxites = new ObservableCollection<ChartPoint>();
            var repairTools = new ObservableCollection<ChartPoint>();

            var storableLimit = new ObservableCollection<ChartPoint>();
            var developmentTool = new ObservableCollection<ChartPoint>();
            var improvementTool = new ObservableCollection<ChartPoint>();
            var instantBuildTool = new ObservableCollection<ChartPoint>();

            foreach (var data in neededData)
            {
                fuels.Add(new ChartPoint(data.DateTime, data.Fuel));
                ammunitions.Add(new ChartPoint(data.DateTime, data.Ammunition));
                steels.Add(new ChartPoint(data.DateTime, data.Steel));
                bauxites.Add(new ChartPoint(data.DateTime, data.Bauxite));
                repairTools.Add(new ChartPoint(data.DateTime, data.RepairTool));
                developmentTool.Add(new ChartPoint(data.DateTime, data.DevelopmentTool));
                improvementTool.Add(new ChartPoint(data.DateTime, data.ImprovementTool));
                instantBuildTool.Add(new ChartPoint(data.DateTime, data.InstantBuildTool));
            }

            var currentDateTime = neededData[neededData.Length - 1].DateTime;

            storableLimit.Add(new ChartPoint(currentDateTime - ChartSettings.DisplayedPeriod.Value.ToTimeSpan(),
                MaterialManager.StorableMaterialLimit));
            storableLimit.Add(new ChartPoint(currentDateTime, MaterialManager.StorableMaterialLimit));

            this.FuelSeries = fuels;
            this.AmmunitionSeries = ammunitions;
            this.SteelSeries = steels;
            this.BauxiteSeries = bauxites;
            this.RepairToolSeries = repairTools;
            this.DevelopmentToolSeries = developmentTool;
            this.ImprovementToolSeries = improvementTool;
            this.InstantBuildToolSeries = instantBuildTool;
            this.StorableLimitSeries = storableLimit;
        }

        /// <summary>
        /// X軸の設定を行います。
        /// </summary>
        private void SetXAxis(TimeMaterialsPair newData)
        {
            // X軸
            XMin = newData.DateTime - ChartSettings.DisplayedPeriod.Value.ToTimeSpan();
            XMax = newData.DateTime;
        }

        /// <summary>
        /// 資材グラフのY軸の設定を行います。
        /// </summary>
        /// <param name="mostMaterial">最も多い資材の量</param>
        private void SetMaterialYAxis(int mostMaterial, int minMaterial)
        {
            this.mostMaterial = Math.Max(mostMaterial, 100);
            this.minMaterial = minMaterial;
            var interval = ChartUtilities.GetInterval(this.minMaterial, this.mostMaterial);
            var chartvisibleList = new[] { IsFuelChartEnable, IsAmmunitionChartEnable, IsSteelChartEnable, IsBauxiteChartEnable };

            YMax1 = chartvisibleList.Any(x => x) ? ChartUtilities.GetYAxisMax(this.mostMaterial, interval) : mostMaterial;
            YMin1 = chartvisibleList.Any(x => x) ? (IsYMinFixedAtZero ? 0 : ChartUtilities.GetYAxisMin(this.minMaterial, interval)) : 0;
        }

        /// <summary>
        /// その他資材グラフのY軸の設定を行います。
        /// </summary>
        /// <param name="mostTool">最も多い高速修復材の量</param>
        private void SetToolYAxis(int mostTool, int minTool)
        {
            this.mostTool = Math.Max(mostTool, 10);
            this.minTool = minTool;
            var interval = ChartUtilities.GetInterval(this.minTool, this.mostTool);
            var chartvisibleList = new[] { IsRepairToolChartEnable, IsImprovementToolChartEnable, IsDevelopmentToolChartEnable, IsInstantBuildToolChartEnable };

            YMax2 = chartvisibleList.Any(x => x) ? ChartUtilities.GetYAxisMax(this.mostTool, interval) : mostTool;
            YMin2 = chartvisibleList.Any(x => x) ? (IsYMinFixedAtZero ? 0 : ChartUtilities.GetYAxisMin(this.minTool, interval)) : 0;
        }

        public async void ExportAsCsv()
        {
            await MaterialManager.Log.ExportAsCsvAsync();
        }

        public async void ImportMaterialData()
        {
            var fileDialog = new OpenFileDialog()
            {
                Filter = "データファイル(*.dat)|*dat|すべてのファイル(*.*)|*.*",
                FilterIndex = 1,
                Title = "インポートデータの選択",
            };

            if (fileDialog.ShowDialog() == true)
            {
                var messageBoxResult = MessageBox.Show("インポートすると、現在のデータは上書きされます。\nよろしいですか？", "上書き確認", MessageBoxButton.OKCancel);
                if (messageBoxResult == MessageBoxResult.OK)
                {
                    await MaterialManager.Log.ImportAsync(fileDialog.FileName);
                }
            }
        }

        public async void ExportMaterialData()
        {
            await MaterialManager.Log.ExportAsync();
        }

		public void SplitReset()
		{
			Split.Reset();
		}
    }
}
