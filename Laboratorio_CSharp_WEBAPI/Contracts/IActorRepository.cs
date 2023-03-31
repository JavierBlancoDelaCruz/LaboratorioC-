using Laboratorio_CSharp_WEBAPI.Models;
using System.Collections.Generic;

namespace Laboratorio_CSharp_WEBAPI.Contracts
{
    public interface IActorRepository //Aquí irán los métodos que vamos a querer implementar en nuestra Api.
    {
        List<Actor> GetActors();
        Actor GetActorById(int id);
        void AddActor(Actor actor);
        void UpdateActor(Actor actor);
        void DeleteActor(int id);

    }
}
