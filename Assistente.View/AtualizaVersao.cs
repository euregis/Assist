using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assistente.Entidades;
using Assistente.Controle;
using Assistente.Negocio;
using System.ComponentModel;
using Assistente.Negocio.Util;

namespace Assistente.View
{
    public static class AtualizaVersao
    {
        public static string VersaoAssembly()
        {
            return typeof(AtualizaVersao).Assembly.GetName().Version.ToString();
        }
        public static string VersaoUltAtualizacao()
        {
            Configuracao confVersao = Conexao.TrataDAO.getConfiguracao().Retorna_pCodigo(1);
            if (confVersao == null)
                return "0.0.0.0";
            else
                return confVersao.Valor;
        }
        public static bool AtualizarScripts()
        {
            string versaoAssembly = VersaoAssembly();
            string versaoAtualiz = VersaoUltAtualizacao();

            string[] versao = versaoAtualiz.Split('.');

            switch (int.Parse(versao[0]))
            {
                case 0:
                    {
                        IncluirConfiguracao(enuConfiguracao.UltimaVersao,
                                TipoValidacao.Nenhuma,
                                versaoAssembly);

                        /*IncluirConfiguracao(enuConfiguracao.ExibirControleHoras,
                                TipoValidacao.SimNao,
                                "Não");

                        IncluirConfiguracao(enuConfiguracao.PosTelaAssistenteCompacto,
                                TipoValidacao.Nenhuma,
                                "T0000L0000");
                        */
                        IncluirConfiguracao(enuConfiguracao.CampoComandosVisivel,
                                TipoValidacao.SimNao,
                                "Não");

                        /*IncluirConfiguracao(enuConfiguracao.ObsIniciarHorario,
                                                        TipoValidacao.SimNao,
                                                        "Sim");

                        IncluirConfiguracao(enuConfiguracao.ModoExibicaoAssistente,
                                                        TipoValidacao.ModoExibicaoAssistente,
                                                        "Systray e Compacto");*/

                        IncluirConfiguracao(enuConfiguracao.ExibirColunaAnotacoes,
                                                        TipoValidacao.SimNao,
                                                        "Não");

                        /*IncluirConfiguracao(enuConfiguracao.ExibirCamposHorarios,
                                                        TipoValidacao.SimNao,
                                                        "Não");*/

                        IncluirConfiguracao(enuConfiguracao.CentralizadorDados,
                                                        TipoValidacao.ArquivoExiste,
                                                        @"\\ad-vw-ap-055\Servmaster\Projetos\GD4253S477\Auxil\Auxiliares\CentralDados\CentralizadorDados.exe");
                        goto case 1;
                    }
                case 1:
                    {
                        switch (int.Parse(versao[1]))
                        {
                            case 0:
                                switch (int.Parse(versao[2]))
                                {
                                    case 0:
                                        switch (int.Parse(versao[3]))
                                        {
                                            case 0:
                                                /*
                                                config = new Configuracao()
                                                {
                                                    Codigo = 1,
                                                    Descricao = "Última versão atualizada",
                                                    Valor = "1.0.0.0"
                                                };
                                                Conexao.TrataDAO.getConfiguracao().Salvar(config);
                                                */

                                                goto default;

                                            default:
                                                break;
                                        }
                                        goto default;

                                    default:
                                        break;
                                }
                                goto default;

                            default:
                                break;
                        }
                    }
                    goto default;
                default:
                    break;
            }




            return true;
        }

        private static void IncluirConfiguracao(enuConfiguracao venuConfiguracao, TipoValidacao venuValidacao, string vstrValor)
        {
            Configuracao config = new Configuracao()
            {
                Codigo = (int)venuConfiguracao,
                Descricao = TrataEnum.ObterDescricao(venuConfiguracao),
                Validacao = (short)venuValidacao,
                Valor = vstrValor
            };
            Conexao.TrataDAO.getConfiguracao().Salvar(config);
        }

    }
}
