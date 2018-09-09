using App_ConsultarCEP.servico.modelo;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

/*Via webservice consultara informacao do cep, traz as informacoes relacionadas ao cep, transferir os dados para a aplicacao*/
namespace App_ConsultarCEP.servico
{
    public class ViaCepServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json";

        /*public method que retornara objeto do tipo Endereco*/
        public static Endereco BuscarEnderecoViaCEP(string cep)
        {   /*reconhece EnderecoURL somente se incluido static na propriedade da classe*/
            string novoenderecourl = string.Format(EnderecoURL,cep);
            /*Buscar cep na internet*/

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoenderecourl); /*Syncron Method: this block the window*/
            /*Deserializar/Converter conteudo do cep para tipo endereco*/

            /*Variable from the type of Endereco
             Neste momento instalar a biblioteca NewtonSoft.json para deserializar conteudo do site viacep
             In this moment I'm converting the json internet content to object from the type endereco*/
            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if(end.cep == null)
            {
                return null;
            }
            return end;
        }
    }
}
