using Ponto.Base.Data.Repository;
using Ponto.Base.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Ponto.ViewModels
{
    public class DetalheViewModel:BaseViewModel
    {
        #region ->Propriedades<-       
        public INavigation Navigation { get; set; }
        private PontoRepository _pontoRepository;
        public Relatorio relatorio { get; set; }
        private List<Base.Models.Ponto> _listaGeral { get; set; }

        private DateTime _diaRelatorio;

        public DateTime DiaRelatorio
        {
            get { return _diaRelatorio; }
            set { _diaRelatorio = value; OnPropertyChanged("DiaRelatorio"); }
        }
        private TimeSpan? _horaJornadaTotal;

        public TimeSpan? HoraJornadaTotal
        {
            get { return _horaJornadaTotal; }
            set { _horaJornadaTotal = value; OnPropertyChanged("HoraJornadaTotal"); }
        }



        private ObservableCollection<Base.Models.Ponto> _pontoList;
        public ObservableCollection<Base.Models.Ponto> PontoList { get { return _pontoList; } set { _pontoList = value; OnPropertyChanged("PontoList"); } }

        #endregion

        #region -> Command <-       

        public void CarregaDados()
        {
            try
            {
                _listaGeral = _pontoRepository.GetPontosDoDia(relatorio.IdUser, relatorio.Inclusao);

                PontoList = new ObservableCollection<Base.Models.Ponto>(_listaGeral);

                DiaRelatorio = relatorio.Inclusao;
                HoraJornadaTotal = relatorio.HrJornada;
            }
            catch (Exception ex)
            {

                App.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
            }
        }
        #endregion
        public DetalheViewModel()
        {
            _pontoRepository = new PontoRepository();
        }
    }
}
