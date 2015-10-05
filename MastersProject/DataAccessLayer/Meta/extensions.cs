
using MastersProject.Core.Common.Enums;
using MastersProject.Core.Common.Interfaces;
using MastersProject.Core.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MastersProject.Core.DataAccessLayer
{

    //Extensions for all classes that are searchable

#region Searchable
    
    public partial class Claim : IObjectState,ISearchable
    {
        private MastersProject.Core.Common.Enums.ObjectState _state;

        public MastersProject.Core.Common.Enums.ObjectState State
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

        public string SearchResultSummary
        {
            get { return String.Format("<div style='background-color:{7}; width: 5px;height: 20px;float:left'></div><b>Claim#:</b> {8} <b>Status:</b> {0} <b>NIS:</b> {1} <b>Name:</b> {2} {3} {4} <b>Gender:</b> {5} <b>Type:</b> {6}", ((ClaimStatus)this.Status).ToString(), this.InsuredPerson.NISNumber, this.InsuredPerson.FirstName, this.InsuredPerson.MiddleName, this.InsuredPerson.SurName, ((Gender)this.InsuredPerson.Sex).ToString().ToString(), this.Benefit.Description, this.Benefit.ColourCode, this.ClaimNo); }
        }

        public string SearchResultType
        {
            get { return  MastersProject.Core.Common.Enums.SearchResultType.Claim.ToString(); }
        }
        
        public bool ContainsKeyword(string keyword)
        {
            return Utils.SearchHelper.AnyMatch(keyword,"[property to search over]" );//this.ClaimNo
        }
       
        public string url
        {
                        get { return "onclick=window.createModalWindow(\'Test\',\'Home\',\'About/2\');"; }
        }
    }




#endregion

#region Others

    public partial class MasterReference : IObjectState
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

    public partial class Address : IObjectState
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

        public string SearchResultSummary
        {
            get { return String.Format("{0} {1}, {2}, {3}", this.LotAptNumber, this.StreetDistrict, this.City,this.ParishStateProvince); }
        }
    }


    public partial class Contact : IObjectState
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

    public partial class Note : IObjectState
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
    public partial class RolePermissions : IObjectState
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
    public partial class NISUsers : IObjectState
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
    public partial class Roles :IObjectState
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
    public partial class Point : IObjectState
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

    public partial class Zone : IObjectState
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


#endregion
}
