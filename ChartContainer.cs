using System;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Charts.Native;
using DevExpress.Data.Browsing;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraPrinting;

namespace ChartConsole {
    public class ChartContainer : IChartContainer, IChartRenderProvider, IChartDataProvider, IChartEventsProvider, IDisposable {
        Chart chart;
        IServiceProvider serviceProvider = null;

        public Size Size { get; set; } = new Size(1200, 800);
        public Chart Chart { get { return chart; } }

        public ChartContainer() {
            chart = new Chart(this);
        }
        #region IDisposable
        void IDisposable.Dispose() {
            if (chart != null) {
                chart.Dispose();
                chart = null;
            }
        }
        #endregion

        #region IChartContainer
        EventHandler endLoading;

        event EventHandler IChartContainer.EndLoading {
            add { endLoading += value; }
            remove { endLoading -= value; }
        }

        Chart IChartContainer.Chart { get { return chart; } }
        ChartContainerType IChartContainer.ControlType { get { return ChartContainerType.WinControl; } }
        IChartDataProvider IChartContainer.DataProvider { get { return this; } }
        IChartRenderProvider IChartContainer.RenderProvider { get { return this; } }
        IChartEventsProvider IChartContainer.EventsProvider { get { return this; } }
        IChartInteractionProvider IChartContainer.InteractionProvider { get { return null; } }
        bool IChartContainer.DesignMode { get { return false; } }
        bool IChartContainer.Loading { get { return false; } }

        bool IChartContainer.ShowDesignerHints { get { return false; } }
        bool IChartContainer.IsDesignControl { get { return false; } }
        bool IChartContainer.IsEndUserDesigner { get { return false; } }
        bool IChartContainer.ShouldEnableFormsSkins { get { return false; } }
        bool IChartContainer.CanDisposeItems { get { return true; } }
        IServiceProvider IChartContainer.ServiceProvider { get { return serviceProvider; } }
        ISite IChartContainer.Site { get; set; }
        IComponent IChartContainer.Parent { get { return null; } }
        SizeF IChartContainer.DpiScaleFactor { get { return new SizeF(1,1); } }

        void IChartContainer.Assign(Chart chart) {
            this.chart.Assign(chart);
        }
        void IChartContainer.Changing() {
        }
        void IChartContainer.Changed() {
        }
        void IChartContainer.LockChangeService() {
        }
        void IChartContainer.UnlockChangeService() {
        }
        void IChartContainer.ShowErrorMessage(string message, string title) {
            ConsoleColor colorBuffer = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(title);
            Console.ForegroundColor = colorBuffer;
            Console.WriteLine(message);
        }
        void IChartContainer.AfterLoadLayout() {
        }
        void IChartContainer.RaiseRangeControlRangeChanged(object minValue, object maxValue, bool invalidate) {
        }
        void IChartContainer.RaiseUIUpdated() {
        }
        void IChartContainer.Invoke(Action action) {
            action();
        }
        bool IChartContainer.GetActualRightToLeft() {
            return false;
        }
        IEndUserFilteringViewModelProvider IChartContainer.GetFilteringViewModelProvider(SeriesFilterHelper filterHelper) {
            return null;
        }
        Point IChartContainer.PointToScreen(Point point) {
            return point;
        }
        #endregion

        #region IChartRenderProvider
        Rectangle IChartRenderProvider.DisplayBounds { get { return new Rectangle(Point.Empty, Size); } }
        bool IChartRenderProvider.IsPrintingAvailable { get { return true; } }
        object IChartRenderProvider.LookAndFeel { get { return null; } }
        IBasePrintable IChartRenderProvider.Printable { get { return null; } }

        ComponentExporter IChartRenderProvider.CreateComponentPrinter(IBasePrintable iPrintable) {
            return new ComponentExporter(iPrintable);
        }
        void IChartRenderProvider.Invalidate() {
        }
        void IChartRenderProvider.InvokeInvalidate() {
        }
        Bitmap IChartRenderProvider.LoadBitmap(string url) {
            return null;
        }
        #endregion

        #region IChartDataProvider
        public event BoundDataChangedEventHandler BoundDataChanged;

        bool IChartDataProvider.CanUseBoundPoints { get; }
        object IChartDataProvider.DataAdapter { get; set; }
        DataContext IChartDataProvider.DataContext { get; }
        object IChartDataProvider.DataSource { get; set; }
        bool IChartDataProvider.SeriesDataSourceVisible { get { return true; } }
        object IChartDataProvider.ParentDataSource { get; }

        void IChartDataProvider.OnBoundDataChanged(EventArgs e) {
            if (BoundDataChanged != null) {
                BoundDataChanged(this, e);
            }
        }
        void IChartDataProvider.OnPivotGridSeriesExcluded(PivotGridSeriesExcludedEventArgs e) {
        }
        void IChartDataProvider.OnPivotGridSeriesPointsExcluded(PivotGridSeriesPointsExcludedEventArgs e) {
        }
        bool IChartDataProvider.ShouldSerializeDataSource(object dataSource) {
            return false;
        }
        #endregion
        
        #region IChartEventsProvider
        bool IChartEventsProvider.ShouldCustomDrawSeries { get { return true; } }
        bool IChartEventsProvider.ShouldCustomDrawAxisLabels { get { return true; } }
        bool IChartEventsProvider.ShouldCustomDrawSeriesPoints { get { return true; } }
        bool IChartEventsProvider.ShouldCustomPaint { get { return true; } }
        bool IChartEventsProvider.ShouldRaiseOnDeserialized { get { return true; } }
        bool IChartEventsProvider.ShouldRaiseDrillDownStateChanged { get { return true; } }
        bool IChartEventsProvider.ShouldRaiseDrillDownStateChanging { get { return true; } }
        bool IChartEventsProvider.ShouldRaiseCustomizeStackedBarTotalLabel { get { return true; } }
        bool IChartEventsProvider.ShouldRaiseCustomizePieTotalLabel { get { return true; } }

        void IChartEventsProvider.OnCustomDrawAxisLabel(CustomDrawAxisLabelEventArgs e) {
        }
        void IChartEventsProvider.OnCustomDrawSeries(CustomDrawSeriesEventArgs e) {
        }
        void IChartEventsProvider.OnCustomDrawSeriesPoint(CustomDrawSeriesPointEventArgs e) {
        }
        void IChartEventsProvider.OnCustomPaint(CustomPaintEventArgs e) {
        }
        void IChartEventsProvider.OnCustomizeAutoBindingSettings(EventArgs e) {
        }
        void IChartEventsProvider.OnCustomizeSimpleDiagramLayout(CustomizeSimpleDiagramLayoutEventArgs e) {
        }
        void IChartEventsProvider.OnPivotChartingCustomizeLegend(CustomizeLegendEventArgs e) {
        }
        void IChartEventsProvider.OnPivotChartingCustomizeResolveOverlappingMode(CustomizeResolveOverlappingModeEventArgs e) {
        }
        void IChartEventsProvider.OnPivotChartingCustomizeXAxisLabels(CustomizeXAxisLabelsEventArgs e) {
        }
        void IChartEventsProvider.OnAxisScaleChanged(AxisScaleChangedEventArgs e) {
        }
        void IChartEventsProvider.OnAxisWholeRangeChanged(AxisRangeChangedEventArgs e) {
        }
        void IChartEventsProvider.OnAxisVisualRangeChanged(AxisRangeChangedEventArgs e) {
        }
        void IChartEventsProvider.OnSmallChartTextShowing(EventArgs e) {
        }
        void IChartEventsProvider.OnDeserialized(EventArgs e) {
        }
        void IChartEventsProvider.OnDrillDownStateChanged(DrillDownStateChangedEventArgs e) {
        }
        bool IChartEventsProvider.OnDrillDownStateChanging(DrillDownStateChangingEventArgs e) {
            return true;
        }
        void IChartEventsProvider.OnCustomizeStackedBarTotalLabel(CustomizeStackedBarTotalLabelEventArgs e) {
        }
        void IChartEventsProvider.OnCustomizePieTotalLabel(CustomizePieTotalLabelEventArgs e) {
        }
        #endregion
    }
}
