using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NIS.NIMS.Data
{
   public partial class InsuredPerson:NIS.NIMS.Common.Interfaces.IObjectState,NIS.NIMS.Common.Interfaces.ISearchable
    {
       private Common.Enums.ObjectState _state;
    

        public Common.Enums.ObjectState State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        public Guid Id
        {
            get { return new Guid(); }
        }

        public string SearchResultSummary
        {
            get { return String.Format("NIS: {0} TRN: {1} Name: {2} {3} {4} DOB: "+this.DOB.ToShortDateString(),this.NISNumber,this.TRN,this.FirstName,this.MiddleName,this.SurName); }
        }

        public string SearchResultType
        {
            get { return NIS.NIMS.Common.Enums.SearchResultType.InsuredPerson.ToString();}
        }

        public string url
        {
            get { return "onclick=window.createModalWindow(\'Test\',\'Home\',\'About/2\');"; }
        }

        public bool ContainsKeyword(string keyword)
        {
            return NIS.NIMS.Common.Utils.Utils.SearchHelper.AnyMatch(keyword,NISNumber,TRN,FirstName,MiddleName,SurName);
        }
    }
   public partial class Contact : NIMS.Common.Interfaces.IObjectState
   {
       private Common.Enums.ObjectState _state;


       public Common.Enums.ObjectState State
       {
           get
           {
               return _state;
           }
           set
           {
               _state = value;
           }
       }
   }
    public partial class Note:NIMS.Common.Interfaces.IObjectState
    {

        public Common.Enums.ObjectState State
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
