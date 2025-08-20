using CandidatosModel;
using System.Collections.Generic;
using System.Linq;
 
namespace CandidatosBusiness;
public class CandidatosService
{
    private static readonly List<CandidatosModel> _candidatos = new();
    private static int _nextId = 1;
 
    public List<CandidatosModel> ListarTodos() => _candidatos;
    public CandidatosModel? ObterPorId(int id) => _candidatos.FirstOrDefault(c => c.Id == id);
 
    public CandidatosModel Criar(CandidatosModel candidato){
        candidato.Id = _nextId++;
        _candidatos.Add(candidato);
        return candidato;
    }

    public bool Atualizar(CandidatosModel candidato){
        var existente = ObterPorId(candidato.Id);
        if (existente == null) return false;
        existente.Nome = candidato.Nome;
        existente.Partido = candidato.Partido;
        existente.Idade = candidato.Idade;
        return true;
    }
 
    public bool Remover(int id)
    {
        var candidato = ObterPorId(id);
        if (candidato == null) return false;
        _candidatos.Remove(candidato);
        return true;
    }
}