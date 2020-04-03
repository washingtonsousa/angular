using Core.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Core.Data.ORM
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly HrDbContext Context;

        public UnityOfWork(HrDbContext context)
        {
            Context = context;
        }

        public void Commit()
        {

            var saved = false;
            while (!saved)
            {
                try
                {
                    // Attempt to save changes to the database
                    this.Context.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {

                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();

                        foreach (var property in proposedValues.Properties)
                        {
                            var proposedValue = proposedValues[property];
                            var databaseValue = databaseValues[property];

                            // TODO: decide which value should be written to database
                            // proposedValues[property] = <value to be saved>;
                        }

                        // Refresh original values to bypass next concurrency check
                        entry.OriginalValues.SetValues(databaseValues);
                    }

                }
                catch (InvalidOperationException ex)
                {
                    // Não faz nada segue processando
                }
            }
        }





        public async Task CommitAsync()
        {

            var saved = false;
            while (!saved)
            {
                try
                {
                    // Attempt to save changes to the database
                    await Context.SaveChangesAsync();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {

                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();

                        foreach (var property in proposedValues.Properties)
                        {
                            var proposedValue = proposedValues[property];
                            var databaseValue = databaseValues[property];

                            // TODO: decide which value should be written to database
                            // proposedValues[property] = <value to be saved>;
                        }

                        // Refresh original values to bypass next concurrency check
                        entry.OriginalValues.SetValues(databaseValues);
                    }

                }
                catch (InvalidOperationException ex)
                {
                    // Não faz nada segue processando
                }
            }
        }
    }
}
