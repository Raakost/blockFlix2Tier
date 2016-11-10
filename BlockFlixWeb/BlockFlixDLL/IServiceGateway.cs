using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlockFlixDLL.Entities;

namespace BlockFlixDLL
{
    public interface IServiceGateway<T> where T : AbstractEntity
    {
        /// <summary>
        /// Get a list of all objects the manager holds.
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();


        /// <summary>
        /// Get a single object, based on its ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        T Get(int ID);


        T Get(string email);


        /// <summary>
        /// Remove an object from the managers list.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Remove(T t);


        /// <summary>
        /// Update/Replace objects in the managers list, that have the same ID as the given object.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Update(T t);


        /// <summary>
        /// Create an object in the manager, this allows the manager to handle ID creation.
        /// Will also automatically call the 'Add()' method to add the object created to the managers list.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T Create(T t);


    }
}
