using IS.Admin.Setup;
using IS.Database;
using IS.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Admin.Model
{
    public class PrincipalsModel
    {
        public IList<Principals> PrincipalList(FrmPrincipals frm, string Keywords)
        {
            var factory = new ISFactory();
            return factory.PrincipalsRepository.Find(Keywords);
        }
        public IList<Principals> PrincipalListWithSelect()
        {
            var factory = new ISFactory();
            return factory.PrincipalsRepository.FindWithSelect();
        }

        public void AddPrincipal(FrmAddPrincipal frm)
        {
            var factory = new ISFactory();
            factory.PrincipalsRepository.Insert(frm._Principals);
        }
        public void InsertPrincipal(Principals model)
        {
            var factory = new ISFactory();
            factory.PrincipalsRepository.Insert(model);
        }
        public bool CheckDup(Principals model)
        {
            var factory = new ISFactory();
            return factory.PrincipalsRepository.PrincipalsStrategy.CheckDuplicate(model.PrincipalId, model.PrincipalName);
        }

        public bool CheckDup(FrmAddPrincipal frm)
        {
           var factory = new ISFactory();
           return factory.PrincipalsRepository.PrincipalsStrategy.CheckDuplicate(frm._Principals.PrincipalId,frm._Principals.PrincipalName);
        }
        public bool CheckEditDup(string name, int? PrincipalId)
        {
            var factory = new ISFactory();
            return factory.PrincipalsRepository.PrincipalsStrategy.CheckEditDuplicate(name, PrincipalId);
        }
        public void UpdatePrincipal(Principals Principal)
        {
            var factory = new ISFactory();
            factory.PrincipalsRepository.Update(Principal);
        }

        public void DeletePrincipal(Principals Principal)
        {
            var factory = new ISFactory();
            factory.PrincipalsRepository.Delete(Principal);
        }
        public Principals LoadEdit(string PrincipalId)
        {
            var factory = new ISFactory();
            return factory.PrincipalsRepository.FindWithPrincipalId(PrincipalId);
        }

        public bool CheckPrincipalIfAlreadyInUse(string PrincipalId)
        {
            var factory = new ISFactory();
            return factory.PrincipalsRepository.PrincipalsStrategy.PrincipalAlreadyInUse(PrincipalId);
        }

        public string GetNextId()
        {
            var factory = new ISFactory();
            return factory.PrincipalsRepository.GetNextId();
        }
    }
}
