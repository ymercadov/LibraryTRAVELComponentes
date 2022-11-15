using System;
using System.Collections.Generic;
using System.Text;

namespace Utilitarios.IoC
{
    public interface IRegisterMoules
    {
        void RegisterTyper<ToFrom, TTo>(bool withIterception = false) where TTo : ToFrom;

        void RegisterTypeWithLifeTime<ToFrom, TTo>(bool withIterception = false) where TTo : ToFrom;
    }
}
