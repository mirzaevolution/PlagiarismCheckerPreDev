using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Plagiarism.DataLayer.Models;

namespace Plagiarism.DataLayer.DataAccess
{
    public class AdminRepository:IDisposable
    {
        private PlagiarismContext _context = new PlagiarismContext();

        public DataResult<IList<Admin>> GetAll()
        {
            bool success = true;
            List<string> errors = new List<string>();
            IList<Admin> list = null;
            try
            {
                list = _context.Administrators.ToList();
            }
            catch(Exception ex)
            {
                success = false;
                errors.Add(ex.Message);
                errors.Add(ex?.InnerException?.Message);
            }
            return new DataResult<IList<Admin>>(list, new StatusResult(success, errors));
        }
        public Admin GetAdminById(int id)
        {
            
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
