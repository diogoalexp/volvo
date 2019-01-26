using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volvo.Domain;

namespace Volvo.DAL.Interface
{
    public interface IModelDAL
    {
        Model get(int id);
        List<Model> getAll();
        Model add(Model model);
        bool delete(int id);
        Model update(Model model);
    }
}
