using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;

namespace RiscServicesHRSharepointAddIn.Repositories
{
  public class RepositoryTemplate : IDisposable
  {

    private bool disposed = false;
    public HrDbContext Context;

    protected RepositoryTemplate()
    {
      this.Context = new HrDbContext();

    }


    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          Context.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    public void Save()
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
        catch(InvalidOperationException ex)
        {
          // Não faz nada segue processando
        }
        }
      }





    public void SaveAsync()
    {

      var saved = false;
      while (!saved)
      {
        try
        {
          // Attempt to save changes to the database
          this.Context.SaveChangesAsync();
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
