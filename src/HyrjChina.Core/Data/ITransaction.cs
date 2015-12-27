using System;

namespace HyrjChina.Core.Data
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
