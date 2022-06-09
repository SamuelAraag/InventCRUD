using System;
using System.Security.Cryptography;
using System.Text;

namespace CRUD_CadastroCliente
{
    public class CriptografarSenha
    {
        public string SenhaDigitada(string senhaDigitadaPeloUsuario)
        {
            Protection protection = new Protection();
            string senhaCriptografada = "";
            try
            {
                UnicodeEncoding ByteConvert = new UnicodeEncoding();
                byte[] dataToEncrypt = ByteConvert.GetBytes(senhaDigitadaPeloUsuario);
                byte[] encrypterData;
                byte[] decrypterData;

                encrypterData = protection.RSAEncrypt(dataToEncrypt);
                string eText = string.Empty;
                foreach (var item in encrypterData)
                {
                    eText += item.ToString() + ", ";
                }

                senhaCriptografada = eText.ToString();
                decrypterData = protection.RSADecrypt(encrypterData);

                Console.WriteLine(Environment.NewLine + $"Valor Descriptografado: {ByteConvert.GetString(decrypterData)}");


            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Erro na criptografia");
            }
            Console.WriteLine(Environment.NewLine + "Precione qualquer tecla para continuar");
            Console.ReadLine();

            return senhaCriptografada;
        }

        public class Protection
        {
            public byte[] RSAEncrypt(byte[] DataToEncrypt)
            {
                try
                {
                    byte[] encryptedData;
                    using (var rsa = new RSACryptoServiceProvider(2048))
                    {
                        rsa.PersistKeyInCsp = false;
                        rsa.FromXmlString("<RSAKeyValue><Modulus>s+nhsnWfULDRzP/RB6PlVmN/hYR8jHn1lE8NWkPxQN4pYoO4OLf3Voi5A/99uVwmiuYHog2zX2n8nD2KkS+3Q1BKK9TSt0sIe9BcTGewQTaIhqySw83zsBUCtxoa9mhnoNOYJEySJyUTt5TJoGwcjBg1acPIPVIoBHGPrSB+Kfk=</Modulus><Exponent>AQAB</Exponent><P>xNJFZMRH9KKdaLqJ3Wp/ZGFzXYhIO+NaAyXF/awnYNdsFLBDF633kfEGtJ8Cc43ga1r0Ss9yeIrUpXKDabamgw==</P><Q>6gIvotoEmep96b6gvBhHI2f9jckBwP0wqN9l11oP70T2xbfQ7g+N36lB2luTNEpWct8bK7J15JACKbC0x+2k0w==</Q><DP>hsBDXFL5xKZUyK/11Y6lO09w0ZeNhNsJ9F+3Jw7nQukaCSwIMz0a42M2KRE4d26qODXkTResEpVSMxesmwK/Cw==</DP><DQ>KHdKT4oOA6PGNFaPqxczrg68jPk2gW4HLRy8mrnrSYAOgHBiA9jSutulFKKDWSaFvoWQSEUrF+RDS3xQNsaEmw==</DQ><InverseQ>RvAgB2W3E+iDCpNiBihAw3WdvCwnZL7gJrdeqn9ulSKgVnx7tdKnayte7fFI6srPtqC1jtoHEzOVHke+JG2BTQ==</InverseQ><D>A0+MfbI4ak22rqUOfauAbuSJ1jUn7ZXY9Q+3WS/i4qSz8kImQ7Tu8kK11OMAt0aA1xGAlnTWFi1nHqDrSdys7KJB/kksa8JoKtBmO5sFrzpD/ex+ffVg+tFBySxOQ235BHzva31CMG+TDn3232XZNBBLFdBSOQIBahORF13F2Jk=</D></RSAKeyValue>");
                        var rsaServer = new RSACryptoServiceProvider(1024);
                        encryptedData = rsa.Encrypt(DataToEncrypt, true);
                    }
                    return encryptedData;
                }
                catch (CryptographicException ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
            //Descriptografar 
            public byte[] RSADecrypt(byte[] DataToDecrypt)
            {
                try
                {
                    byte[] decryptedData;
                    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
                    {
                        var privateKey = rsa.ToXmlString(true);
                        rsa.FromXmlString("<RSAKeyValue><Modulus>s+nhsnWfULDRzP/RB6PlVmN/hYR8jHn1lE8NWkPxQN4pYoO4OLf3Voi5A/99uVwmiuYHog2zX2n8nD2KkS+3Q1BKK9TSt0sIe9BcTGewQTaIhqySw83zsBUCtxoa9mhnoNOYJEySJyUTt5TJoGwcjBg1acPIPVIoBHGPrSB+Kfk=</Modulus><Exponent>AQAB</Exponent><P>xNJFZMRH9KKdaLqJ3Wp/ZGFzXYhIO+NaAyXF/awnYNdsFLBDF633kfEGtJ8Cc43ga1r0Ss9yeIrUpXKDabamgw==</P><Q>6gIvotoEmep96b6gvBhHI2f9jckBwP0wqN9l11oP70T2xbfQ7g+N36lB2luTNEpWct8bK7J15JACKbC0x+2k0w==</Q><DP>hsBDXFL5xKZUyK/11Y6lO09w0ZeNhNsJ9F+3Jw7nQukaCSwIMz0a42M2KRE4d26qODXkTResEpVSMxesmwK/Cw==</DP><DQ>KHdKT4oOA6PGNFaPqxczrg68jPk2gW4HLRy8mrnrSYAOgHBiA9jSutulFKKDWSaFvoWQSEUrF+RDS3xQNsaEmw==</DQ><InverseQ>RvAgB2W3E+iDCpNiBihAw3WdvCwnZL7gJrdeqn9ulSKgVnx7tdKnayte7fFI6srPtqC1jtoHEzOVHke+JG2BTQ==</InverseQ><D>A0+MfbI4ak22rqUOfauAbuSJ1jUn7ZXY9Q+3WS/i4qSz8kImQ7Tu8kK11OMAt0aA1xGAlnTWFi1nHqDrSdys7KJB/kksa8JoKtBmO5sFrzpD/ex+ffVg+tFBySxOQ235BHzva31CMG+TDn3232XZNBBLFdBSOQIBahORF13F2Jk=</D></RSAKeyValue>");
                        decryptedData = rsa.Decrypt(DataToDecrypt, true);
                    }
                    return decryptedData;
                }
                catch (CryptographicException ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }
        
    }
}
