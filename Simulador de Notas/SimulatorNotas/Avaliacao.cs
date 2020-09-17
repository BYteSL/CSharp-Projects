//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="IPCA">
// Copyright (c) IPCA. All rights reserved.</copyright>
//-----------------------------------------------------------------------
// <author>Yuri Lemos</author>
// <desc> This program do the basics of C#</desc>
// <Date> 4 / 4 / 2020 </Date>
// <version>1.0</version>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorNotas
{
    /// <summary>
    /// 
    /// </summary>
    class Avaliacao
    {

        #region Atributos
        List<float> testes, trabalhos;
        float assiduidade,totalTestes,totalTrabalhos;
        float pesoTestes, pesoTrabalhos;
        #endregion

        #region Construtor
        public Avaliacao()
        {
            testes = new List<float>();
            trabalhos = new List<float>();
            assiduidade = 0;
            totalTestes = 0;
            totalTrabalhos = 0;
            pesoTestes = 0;
            pesoTrabalhos = 0;
        }
        #endregion

        #region Propriedades
        public float Assiduidade
        {
            get { return assiduidade; }
            set { assiduidade = value; }
        }
        public List<float> Testes
        {
            get { return testes; }
        }
        #endregion

        #region Metodos
        public void AdicionarNotaTeste(float nota, float peso)
        {
            float notaCalculada;
            notaCalculada = nota * (peso / 100);
            totalTestes += notaCalculada;
            testes.Add(notaCalculada);
        }
        public void AdicionarNotaTrabalho(float nota, float peso)
        {
            float notaCalculada;
            notaCalculada = nota * (peso / 100);
            totalTrabalhos += notaCalculada;
            trabalhos.Add(notaCalculada);
        }
        public float CalcularNotaFinal()
        {
            float notaFinal;
            notaFinal = (pesoTestes * totalTestes) + (pesoTrabalhos * totalTrabalhos) + (assiduidade);
            return notaFinal;
        }
        #endregion

    }
}
