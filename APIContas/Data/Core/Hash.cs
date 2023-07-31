using System.Security.Cryptography;
using System.Text;

namespace APIContas.Data.Core;

public class Hash
{
    private readonly string _key = "2023vc3202";
    private readonly HashAlgorithm _algoritmo;

    public Hash(HashAlgorithm algoritmo) => (_algoritmo) = (algoritmo);
    
    public string Criptografar(string senha)
    {
        var encryptedPassword = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(_key + senha));

        var sb = new StringBuilder();

        foreach (var caracter in encryptedPassword)
            sb.Append(caracter.ToString("X2"));

        return sb.ToString();
    }

    public bool VerificarSenha(string senhaDigitada, string senhaCadastrada)
    {
        var encryptedPassord = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(_key + senhaDigitada));

        var sb = new StringBuilder();

        foreach (var caracter in encryptedPassord)
            sb.Append(caracter.ToString("X2"));

        return sb.ToString() == senhaCadastrada;
    }
}
