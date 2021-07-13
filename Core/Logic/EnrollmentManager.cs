using Core.Models;
using Core.Persistence;
using System;
using System.Linq;

namespace Core.Logic
{
    public class EnrollmentManager : Manager
    {
        public EnrollmentManager(IRepository repository ) : base(repository) { }

        public ResponseData<Registration> RequestEntry(Registration data) => Exec((repo) =>
        {
            // check if exists
            if (repo.Find<Registration>(r => r.Identification == data.Identification)?.Count() > 0)
                return Error<Registration>(message: "Usted ya ha sido registrado");
            var val = data.Validate();
            if (val?.Count > 0)
                return Error<Registration>(val, "Formato inválido verifique los detalles");
            var reg = repo.NewRecord(data);
            return Success(reg, "!Enhorabuena su registro ha sido completado!");
        });

        public ResponseData<Registration> UpdateEntry(Registration data) => Exec((repo) =>
        {
            // check if exists
            if (repo.Find<Registration>(r => r.Identification == data.Identification)?.Count() == 0)
                return Error<Registration>(message: "Registro no encontrado");
            var val = data.Validate();
            if (val?.Count > 0)
                return Error<Registration>(val, "Formato inválido verifique los detalles");
            var reg = repo.UpdateRecord(data);
            return Success(reg, "!Enhorabuena su registro ha sido actualizado!");
        });

        public ResponseData<Registration> DeleteEntry(Guid id) => Exec((repo) =>
        {
            // check if exists
            var rec = repo.Find<Registration>(r => r.Id == id).FirstOrDefault();
            if (rec is null)
                return Error<Registration>(message: "Registro no encontrado");
            repo.DeleteRecord(rec);
            return Success(rec, "Registro eliminado");
        });

        public ResponseData<Registration> DeleteEntry(Registration data) => Exec((repo) =>
        {
            // check if exists
            var rec = repo.Find<Registration>(r => r.Identification == data.Identification).FirstOrDefault();
            if (rec is null)
                return Error<Registration>(message: "Registro no encontrado");
            repo.DeleteRecord(rec);
            return Success(data, "Registro eliminado");
        });

        public ResponseData<Registration> GetRecords() => Exec((repo) =>
        {
            return Success(repo.GetRecords());
        });
    }
}
