using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_ConsultarCEP.servico.modelo; //Conteudo que sera retornado pelo site viacep, por webservice
using App_ConsultarCEP.servico; //Busca cep do site viacep por webservice

namespace App_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            /*Ao clicar no botao executara comando
             Criar evento que sera utilizado pelo evento de clicar o botao*/
            BOTAO.Clicked += BuscarCEP;
		}
        /*Evento utilizado pelo evento de clicar do botao*/
        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO: Program Logic
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try { 
                Endereco end = ViaCepServico.BuscarEnderecoViaCEP(cep);
                
                    if(end != null)
                    {
                        RESULTADO.Text = string.Format("Endereco {2} de {3} {0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO 003","Address did not find for the CEP","Out");
                    }
                
                }
                catch(Exception e)
                {
                DisplayAlert("CRITICAL ERROR 001",e.Message,"Out");
                }
            }
         }

        //TODO: Validations
        private bool isValidCEP(string cep)
        {
            bool valido = true;
            if(cep.Length !=8 )
            {
                //TODO: ERRO
                DisplayAlert("ERR 001", "Invalid CEP! Enter 8 characters for CEP", "OK");
                valido = false;
            }
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
            {
                //TODO: ERRO
                DisplayAlert("ERR 002","Invalid CEP! Enter just number for CEP","OK");
                valido = false;
            }

            return valido;
        }
	}
}
