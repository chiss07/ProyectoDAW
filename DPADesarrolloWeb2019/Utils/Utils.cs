using DesarrolloBE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DPADesarrolloWeb2019.Utils
{
    public class Utils
    {
        
        public static List<Puesto_trabajo> csvLoad(string filePath, bool hasHeader)
        {
            List<Puesto_trabajo> retorno = null;

            using (var reader = new StreamReader(filePath))
            {
                retorno = new List<Puesto_trabajo>();
                Puesto_trabajo single = null;                 

                if (hasHeader)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(Constants.FILE_SEPARATOR_CHAR);

                    single = new Puesto_trabajo()
                    {
                        Documento_identidad = values[0],
                        NombreCompleto = values[1]
                    };
                    retorno.Add(single);
                    
                }
                return retorno;
            }
        }

        public static List<Puesto_trabajo> csvProcessing(string filePath, bool hasHeader)
        {
            List<Puesto_trabajo> retorno = null;

            using (var reader = new StreamReader(filePath))
            {
                retorno = new List<Puesto_trabajo>();
                Puesto_trabajo single = null;

                if (hasHeader)
                    reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(Constants.FILE_SEPARATOR_CHAR);

                    single = new Puesto_trabajo()
                    {
                        Documento_identidad = values[0],
                        MedidaVisual = Convert.ToDecimal(values[1]),
                        MedidaAuditiva = Convert.ToDecimal(values[2])
                    };
                    retorno.Add(single);

                }
                return retorno;
            }
        }
    }
}