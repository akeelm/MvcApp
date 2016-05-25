using Moq;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MvcApp.Tests.Repository.Data
{
    /// <summary>
    /// This is the mock / fake session for the pluggable IDataSession / DbContext.
    /// </summary>
    public static class DataHelper
    {
        public static IDataSession Session()
        {
            return new MockDataSession();
        }

        public static IDataSession Session<T>(params T[] set) where T : class
        {
            return Session().AddSet(set);
        }

        public static IDataSession AddSet<T>(this IDataSession session, params T[] set) where T : class
        {
            var mockSession = session as MockDataSession;
            if (mockSession == null)
                throw new Exception(string.Format("Data store must of type MockDataStore.  Got type '{0}' instead", session.GetType()));

            mockSession
                .Mock
                .Setup(x => x.Set<T>())
                .Returns(set == null ? new FakeDbSet<T>() : new FakeDbSet<T>(set));

            return mockSession;
        }

        private class MockDataSession : IDataSession
        {
            private Mock<IDataSession> _mock = new Mock<IDataSession>();

            internal Mock<IDataSession> Mock
            {
                get { return _mock; }
            }

            public void Dispose() { }

            IDbSet<T> IDataSession.Set<T>()
            {
                return _mock.Object.Set<T>();
            }

            //Not needed for testing
            public IEnumerable<T> SqlQuery<T>(string sql, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            //Not needed for testing
            public int SaveChanges() { return 0; }

            public int SqlCommand(string sql, params object[] parameters)
            {
                throw new NotImplementedException();
            }

            //Not needed for testing
            public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
            {
                throw new NotImplementedException();
            }
        }
    }
}
