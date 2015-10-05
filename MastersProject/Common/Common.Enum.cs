using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MastersProject.Core.Common.Enums
{

    public enum SearchResultType
    {
        [Description("Insured Person")]
        InsuredPerson = 1,
        Employer = 2,
        Claim = 3,
        Book = 4,
        Voucher = 5,
        Contribution = 6,
        Branch = 7,
        Agent = 8,
        Claimant = 9

    }

    public enum ObjectState
    {
        Unchanged,
        Added,
        Modified,
        Deleted
    }
    /// <summary>
    

    [DataContract]
    public enum ErrorMessageType
    {
        [EnumMember]
        LoadingData = 1,
        [EnumMember]
        WritingData = 2,
        [EnumMember]
        DeletingData = 3,
        [EnumMember]
        Concurrency = 4
    }

    [DataContract]
    public enum Gender
    {
        [EnumMember]
        Male = 1,
        [EnumMember]
        Female = 2
    }

    [DataContract]
    public enum Title
    {
        [EnumMember]
        [Description("Mr.")]
        Mr = 1,
        [EnumMember]
        [Description("Ms.")]
        Ms = 2,
        [EnumMember]
        [Description("Mrs.")]
        Mrs = 3
    }

    [DataContract]
    public enum EmploymentType
    {
        [EnumMember]
        Casual,
        [EnumMember]
        Domestic,
        [EnumMember]
        Government
    }
    public enum MaritalStatus
    {
        Single,
        Married,
        CommonLaw,
        Separated,
        Widowed,
        Divorced
    }

    

   
    public enum Country
    {
        Jamaica = 35
    }


    [DataContract]
    public enum ContactEntity
    {
        [EnumMember]
        InsuredPerson = 1,
        [EnumMember]
        Employer = 2,
        [EnumMember]
        EmployerBranch = 3,
        [EnumMember]
        EmployerDirector = 4,
        [EnumMember]
        Agent = 5,
        [EnumMember]
        Claimant = 6
    }

    [DataContract]
    public enum NoteEntity
    {
        [EnumMember]
        Claim = 55,
        [EnumMember]
        Employer = 56,
        [EnumMember]
        InsuredPerson = 57
    }

    [DataContract]
    public enum ContactType
    {
        [EnumMember]
        LandLine = 43,
        [EnumMember]
        Email = 44,
        [EnumMember]
        Mobile = 45,
        [EnumMember]
        Fax = 46
    }

    [DataContract]
    public enum ParentType
    {
        [EnumMember]
        Mother = 47,
        [EnumMember]
        Father = 48,
        [EnumMember]
        Guardian = 49
    }

    [DataContract]
    public enum Key
    {
        [EnumMember]
        [Description("Official Documents")]
        DocumentName,
        [EnumMember]
        [Description("Parishes in Jamaica")]
        Parishes,
        [EnumMember]
        [Description("Title attached to name")]
        Title,
        [EnumMember]
        [Description("Gender")]
        Gender,
        [EnumMember]
        [Description("Nationality")]
        Nationality,
        [EnumMember]
        [Description("Occupation Category")]
        Occupation,
        [Description("Type of Employment for NIS")]
        [EnumMember]
        EmploymentType,
        [EnumMember]
        [Description("Marital Status")]
        MaritalStatus,
        [EnumMember]
        [Description("Country")]
        Country,
        [EnumMember]
        [Description("Process(task) in the application")]
        Process,
        [EnumMember]
        [Description("Contact information for whom")]
        ContactEntity,
        [EnumMember]
        [Description("Type of Parent")]
        ParentType,
        [EnumMember]
        [Description("Type of Contact Information")]
        ContactType,
        [EnumMember]
        [Description("Proof a document is in support of")]
        ProofType,
        [EnumMember]
        [Description("What a note is in reference to")]
        NoteEntity,
        [EnumMember]
        [Description("What is being verified")]
        VerificationType,
        [EnumMember]
        [Description("What a notification is about")]
        NotificationType,
        [EnumMember]
        [Description("Source of Contribution")]
        ContributionSource,
        [EnumMember]
        [Description("Status of an employer")]
        EmployerStatus,
        [EnumMember]
        [Description("Failure reasons for imports")]
        ImportFileType,
        [EnumMember]
        [Description("Type of Business")]
        DscEmpType,
        [EnumMember]
        [Description("Type of Address")]
        AddressType,
        [EnumMember]
        [Description("Type of Import being done")]
        ImportSourceType,
        [EnumMember]
        [Description("Position in company")]
        Position,
        [EnumMember]
        [Description("Type of Claim")]
        ClaimType,
        [EnumMember]
        [Description("Status of Claim")]
        ClaimStatus,
        [EnumMember]
        [Description("Status of Payment")]
        PaymentStatus,
        [EnumMember]
        [Description("Countries that have reciprocal agreement")]
        ReciprocalCountry,
        [EnumMember]
        [Description("Type of Rate")]
        Rate,
        [EnumMember]
        [Description("Type of Account")]
        AccountType,
        [EnumMember]
        [Description("Medical Bill Status")]
        MedicalBillType,
        [EnumMember]
        [Description("Assessment Type")]
        AssessmentType,
        [EnumMember]
        [Description("Transaction Type")]
        TransactionType,
        [EnumMember]
        [Description("Reason for closing claim")]
        CloseReason,
        [EnumMember]
        [Description("Reason for disallowing claim")]
        DisallowReason,
        [EnumMember]
        [Description("Type of payment cycle")]
        PaymentCycle
    }



    [DataContract]
    public enum NotificationType
    {
        [EnumMember]
        Alert=73,
        [EnumMember]
        Notification=74
    }

    [DataContract]
    public enum VerificationType
    {
        [EnumMember]
        [Description("Insured Person Registration")]
        InsuredPersonRegistration = 1,
        [EnumMember]
        [Description("Life Status Change")]
        LifeStatusChange = 2,
        [EnumMember]
        [Description("Contribution Addition")]
        ContributionAddition = 3,        
        [EnumMember]
        [Description("Contribution Transfer")]
        Transfer = 4,
        [EnumMember]
        [Description("Employer Registration")]
        EmployerRegistration = 5,
        [EnumMember]
        [Description("Branch Registration")]
        BranchRegistration = 6,
        [EnumMember]
        [Description("Insured Name Change")]
        InsuredNameChange = 7,
        [EnumMember]
        [Description("Employer Name Change")]
        EmployerNameChange = 8,
        [EnumMember]
        [Description("Employer Status Change")]
        EmployerStatusChange = 9,
        [EnumMember]
        [Description("Insured NIS Change")]
        InsuredNISChange = 10,
        [EnumMember]
        [Description("Insured Address Edit")]
        InsuredAddressEdit = 11,
        [EnumMember]
        [Description("Insured Address Addition")]
        InsuredAddressAddition = 12,
        [EnumMember]
        [Description("Employer Address Edit")]
        EmployerAddressEdit = 13,
        [EnumMember]
        [Description("Employer Address Addition")]
        EmployerAddressAddition = 14,
        [EnumMember]
        [Description("Employer Director Change")]
        EmployerDirectorChange = 15,
        [EnumMember]
        [Description("Global Transfer")]
        GlobalTransfer = 16,
        [EnumMember]
        [Description("Insured Address Removal")]
        InsuredAddressRemoval = 17,
        [EnumMember]
        [Description("Employer Address Removal")]
        EmployerAddressRemoval = 18,
        [EnumMember]
        [Description("Branch Removal")]
        BranchRemoval = 19,
        [EnumMember]
        [Description("Branch Edit")]
        BranchEdit = 20,
        [EnumMember]
        [Description("Agent Addition")]
        AgentAddition = 21,
        [EnumMember]
        [Description("Claim Logged")]
        ClaimLogged = 22,
        [EnumMember]
        [Description("Agent Removal")]
        AgentRemoval = 23,
        [EnumMember]
        [Description("Agent Name Change")]
        AgentNameChange = 24,
        [EnumMember]
        [Description("Agent Address Change")]
        AgentAddressChange = 25,
        [EnumMember]
        [Description("Banking Details Addition")]
        BankingDetailsAddition = 26,
        [EnumMember]
        [Description("Banking Details Removal")]
        BankingDetailsRemoval = 27,
        [EnumMember]
        [Description("Spouse Removal")]
        SpouseRemoval = 28,
        [EnumMember]
        [Description("Spouse Addition")]
        SpouseAddition = 29,
        [EnumMember]
        [Description("Spouse Edit")]
        SpouseEdit = 30,
        [EnumMember]
        [Description("Banking Details Edit")]
        BankingDetailsEdit = 31,
        [EnumMember]
        [Description("Claim Edit")]
        ClaimEdit = 32,
        [EnumMember]
        [Description("Child Addition")]
        ChildAddition = 33,
        [EnumMember]
        [Description("Child Details Removal")]
        ChildDetailsRemoval = 34,
        [EnumMember]
        [Description("Certificate Addition")]
        CertificateAddition = 35,
        [EnumMember]
        [Description("Certificate Removal")]
        CertificateRemoval = 36,
        [EnumMember]
        [Description("Medical Bill Addition")]
        MedicalBillAddition = 37,
        [EnumMember]
        [Description("Medical Bill Removal")]
        MedicalBillRemoval = 38,
        [EnumMember]
        [Description("Assessment Addition")]
        AssessmentAddition = 39,
        [EnumMember]
        [Description("Assessment Removal")]
        AssessmentRemoval = 40,
        [EnumMember]
        [Description("Claimant Name Change")]
        ClaimantNameChange = 41,
        [EnumMember]
        [Description("Insured DOB Edit")]
        InsuredDOBEdit = 42,
        [EnumMember]
        [Description("Insured Gender Edit")]
        InsuredGenderEdit = 43,
        [EnumMember]
        [Description("Claimant Address Change")]
        ClaimantAddressChange = 44,
        [EnumMember]
        [Description("Claimant Life Status Change")]
        ClaimantStatusChange = 45,
        [EnumMember]
        [Description("Finalize Payment Plan")]
        PaymentFinalize = 46,
        [EnumMember]
        [Description("Employment History Addition")]
        EmploymentHistoryAdd = 47,
        [EnumMember]
        [Description("Stop Adjustment Plan")]
        StopAdjustmentPlan = 48,
        [EnumMember]
        [Description("Add Adjustment Plan")]
        AddAdjustmentPlan = 49,
        [EnumMember]
        [Description("Disallow Claim")]
        DisallowClaim = 50,
        [EnumMember]
        [Description("Verified Contribution Removal")]
        VerifiedContributionRemoval = 51,
    }

    [DataContract]
    public enum Permissions//131 last count
    {
        ///////////////////////admin//////////////////
        [EnumMember]
        Can_Create_User=0,
        [EnumMember]
        Can_Edit_User=1,
        [EnumMember]
        Can_Delete_User=2,
        [EnumMember]
        Can_View_Users=115,

        [EnumMember]
        Can_Create_Role=3,
        [EnumMember]
        Can_Delete_Role=4,
        [EnumMember]
        Can_Edit_Role=111,
        [EnumMember]
        Can_Remove_RolePermission=112,
        [EnumMember]
        Can_Add_RolePermission = 113,
        [EnumMember]
        Can_View_Roles = 114,

        [EnumMember]
        Can_View_Required_Documents=5,
        [EnumMember]
        Can_Add_Required_Documents=6,

        [EnumMember]
        Can_View_Master_References=7,
        [EnumMember]
        Can_Add_Master_References=8,
        [EnumMember]
        Can_Edit_Master_References=9,
        /////////////////////////insured///////////////

        //registration
        [EnumMember]
        Can_Register_Insured = 10,
        [EnumMember]
        Can_View_Insured = 11,
        [EnumMember]
        Can_Verify_Insured_Registration = 12,

        //NIS Number
        [EnumMember]
        Can_Assign_NewNISNumber = 13,
        [EnumMember]
        Can_Verify_NewNISNumber = 14,

        //status change
        [EnumMember]
        Can_Change_Insured_Status = 15,
        [EnumMember]
        Can_Verify_Insured_Status_Change = 16,

        //name change
        [EnumMember]
        Can_Change_Insured_Name = 17,
        [EnumMember]
        Can_Verify_Insured_Name_Change = 18,

        //address
        [EnumMember]
        Can_Add_Insured_Address = 19,
        [EnumMember]
        Can_Edit_Insured_Address = 20,
        [EnumMember]
        Can_Remove_Insured_Address = 21,

        [EnumMember]
        Can_Verify_Insured_Address_Addition = 22,
        [EnumMember]
        Can_Verify_Insured_Address_Edit = 23,
        [EnumMember]
        Can_Verify_Insured_Address_Removal = 24,

        [EnumMember]
        Can_Edit_Insured_DOB = 120,
        [EnumMember]
        Can_Verify_Insured_DOB_Edit = 121,

        ////////////////////////empoyer/////////////////

        //registration
        [EnumMember]
        Can_Register_Employer = 25,
        [EnumMember]
        Can_View_Employer = 26,
        [EnumMember]
        Can_Verify_Employer_Registration = 27,

        //status change
        [EnumMember]
        Can_Change_Employer_Status = 28,
        [EnumMember]
        Can_Verify_Employer_Status_Change = 29,

        //name change
        [EnumMember]
        Can_Change_Employer_Name = 30,
        [EnumMember]
        Can_Verify_Employer_Name_Change = 31,

        //address
        [EnumMember]
        Can_Add_Employer_Address = 32,
        [EnumMember]
        Can_Edit_Employer_Address = 33,
        [EnumMember]
        Can_Remove_Employer_Address = 34,

        [EnumMember]
        Can_Verify_Employer_Address_Addition = 35,
        [EnumMember]
        Can_Verify_Employer_Address_Edit = 36,
        [EnumMember]
        Can_Verify_Employer_Address_Removal = 37,

        //Branch
        [EnumMember]
        Can_Add_Branch = 38,
        [EnumMember]
        Can_Edit_Branch = 39,
        [EnumMember]
        Can_Remove_Branch = 40,

        [EnumMember]
        Can_Verify_Branch_Addition = 41,
        [EnumMember]
        Can_Verify_Branch_Edit = 42,
        [EnumMember]
        Can_Verify_Branch_Removal = 43,

        [EnumMember]
        Can_View_Branch = 44,

        //director
        [EnumMember]
        Can_Edit_Manging_Director = 45,
        [EnumMember]
        Can_Verify_Managing_Director_Edit = 46,


        ////////////////////contributions////////////////////////
        [EnumMember]
        Can_View_Contribution = 47,

        [EnumMember]
        Can_Add_Contribution = 48,
        [EnumMember]
        Can_Verify_Contribution = 49,

        [EnumMember]
        Can_Remove_Contribution = 50,
        [EnumMember]
        Can_Verify_Contribution_Removal = 51,

        //transfer
        [EnumMember]
        Can_Transfer = 52,
        [EnumMember]
        Can_Verify_Transfer = 53,
        [EnumMember]
        Can_View_Transfer = 54,

        //global transfer
        [EnumMember]
        Can_Global_Transfer = 55,
        [EnumMember]
        Can_Verify_Global_Transfer = 56,

        ///////////////////////Claim//////////////////
        [EnumMember]
        Can_Create_Claim = 57,
        [EnumMember]
        Can_Verify_Claim = 58,
        [EnumMember]
        Can_Add_Agent = 59,
        [EnumMember]
        Can_Verify_Agent_Addition = 60,
        [EnumMember]
        Can_Remove_Agent = 61,
        [EnumMember]
        Can_Verify_Agent_Removal = 62,
        [EnumMember]
        Can_Edit_Agent = 63,
        [EnumMember]
        Can_Edit_Claimant = 118,
        [EnumMember]
        Can_Verify_Agent_Edit = 64,
        [EnumMember]
        Can_View_Agent = 65,
        [EnumMember]
        Can_View_Claim = 66,
        [EnumMember]
        Can_Edit_Banking = 67,
        [EnumMember]
        Can_Remove_Banking = 68,
        [EnumMember]
        Can_Remove_Spouse = 69,
        [EnumMember]
        Can_Add_Spouse = 70,
        [EnumMember]
        Can_Edit_Claim = 71,
        [EnumMember]
        Can_Edit_Spouse = 72,
        [EnumMember]
        Can_Add_Banking = 73,
        [EnumMember]
        Can_Verify_Claimant_Edit = 119,
        [EnumMember]
        Can_Verify_Banking_Addition = 74,
        [EnumMember]
        Can_Verify_Banking_Removal = 75,
        [EnumMember]
        Can_Verify_Spouse_Addition = 76,
        [EnumMember]
        Can_Verify_Spouse_Removal = 77,
        [EnumMember]
        Can_Verify_Spouse_Edit = 110,
        [EnumMember]
        Can_Verify_Banking_Edit = 78,
        [EnumMember]
        Can_Verify_Claim_Edit = 79,
        [EnumMember]
        Can_Reject_Claim = 80,
        [EnumMember]
        Can_Finalize_Claim = 81,
        [EnumMember]
        Can_Reinstate_Claim = 103,
        [EnumMember]
        Can_Track_Claim_To_Individual = 98,
        [EnumMember]
        Can_Track_Claim_To_Department = 99,
        [EnumMember]
        Can_Track_Claim = 100,
        [EnumMember]
        Can_Assign_Claim = 101,
        [EnumMember]
        Can_Reassign_Claim = 102,

        [EnumMember]
        Can_Add_Child = 86,
        [EnumMember]
        Can_Verify_Child_Addition = 87,
        [EnumMember]
        Can_Verify_Child_Removal = 88,
        [EnumMember]
        Can_Remove_Child = 89,
        [EnumMember]
        Can_Add_Certificate = 90,
        [EnumMember]
        Can_Verify_Certificate_Addition = 91,
        [EnumMember]
        Can_Remove_Certificate = 92,
        [EnumMember]
        Can_Verify_Certificate_Removal = 93,
        [EnumMember]
        Can_Add_Medical_Bill = 94,
        [EnumMember]
        Can_Verify_Medical_Bill_Addition = 95,
        [EnumMember]
        Can_Remove_Medical_Bill = 96,
        [EnumMember]
        Can_Verify_Medical_Bill_Removal = 97,

        [EnumMember]
        Can_Add_DS = 109,
        [EnumMember]
        Can_Verify_DS_Addition = 104,
        [EnumMember]
        Can_Remove_DS = 105,
        [EnumMember]
        Can_Verify_DS_Removal = 106,
        [EnumMember]
        Can_Edit_DS = 107,
        [EnumMember]
        Can_Verify_DS_Edit = 108,

        //////////////Home Page//////////
        [EnumMember]
        Can_View_Insured_Statistics = 82,
        [EnumMember]
        Can_View_Registered_Employers_Statistics = 83,
        [EnumMember]
        Can_View_Verified_Claims_Statistics = 84,
        [EnumMember]
        Can_View_Contributions_Statistics = 85,

        [EnumMember]
        Can_View_Insured_Contributions = 116,
        [EnumMember]
        Can_View_Claimant = 117,
        [EnumMember]
        Can_Finalize_Payment = 122,
        [EnumMember]
        Can_View_Insured_Banking = 123,
        [EnumMember]
        Can_View_Insured_Contact = 124,
        [EnumMember]
        Can_Stop_Adjustment_Plan = 125,
        [EnumMember]
        Can_Verify_Stop_Adjustment_Plan = 126,
        [EnumMember]
        Can_Add_Adjustment_Plan = 127,
        [EnumMember]
        Can_Verify_Add_Adjustment_Plan = 128,
        [EnumMember]
        Can_Disallow_Claim = 129,
        [EnumMember]
        Can_Verify_Disallow_Claim = 130,

        //Compliance
        [EnumMember]
        Can_Manage_Intinerary_Report = 131
    }

    public enum ContributionSource
    {
        [Description("SO2")]
        SO2,
        [Description("C7")]
        C7,
        [Description("Demand Notice")]
        Demand_Notice,
        [Description("Payslip")]
        Payslip,
        [Description("Service Record")]
        Service_Record,
        [Description("Stamp Card (Self-Employed)")]
        Stamp_Card_SelfEmployed=75,
        [Description("Stamp Card (Domestic)")]
        Stamp_Card_Domestic=483,
        [Description("Stamp Card ( Voluntary)")]
        Stamp_Card_Voluntary=484
    }

    public enum Employerstatus
    {
        Active,
        Closed
    }

    public enum AddressType
    {
        [Description("Insured Residential Address")]
        InsuredResidentialAddress=110,
        [Description("Insured Employer Address")]
        InsuredEmployerAddress=111,
        [Description("Employer Company Address")]
        EmployerCompanyAddress=112,
        [Description("Employer Mailing Address")]
        EmployerMailingAddress=113,
        [Description("Record Location")]
        RecordLocation=114,
        [Description("Branch Company Address")]
        BranchCompanyAddress=115,
        [Description("Branch Mailing Address")]
        BranchMailingAddress=116,
        [Description("Director Residential Address")]
        DirectorResidentialAddress=117,
        [Description("Agent Address")]
        AgentAddress=510,
        [Description("Claimant Address")]
        ClaimantAddress=1538,
        [Description("Employment History Address")]
        EmployerHistory = 2538
    }

    [DataContract]
    public enum MessageType
    {
        [EnumMember]
        RecordUpdate = 1,
        [EnumMember]
        RecordTracked = 2
    }


    public enum ClaimType
    {
        [Description("Old Age")]
        OA,
        [Description("Funeral Grant")]
        FG,
        [Description("Anniversary")]
        ANN,
        [Description("Employment Injury")]
        EIB,
        [Description("Invalidity")]
        IN,
        [Description("Disablement")]
        DS,
        [Description("Maternity")]
        MAT,
        [Description("Employment Injury Death")]
        EIDB,
        [Description("Widow/Widower")]
        WD,
        [Description("Special Child")]
        SC,
        [Description("Orphan")]
        OR
    }

    [DataContract]
    public enum AccountType
    {
        [EnumMember]
        [Description("Savings")]
        Savings = 1,
        [EnumMember]
        [Description("Chequing")]
        Chequing = 2
    } 

    public enum Bank
    {
        NCB,
        BNS,
        FirstCaribbean,
        RBC,
        RBTT
    }

    public enum ClaimStatus
    {
        [Description("The claim is created but not verified")]
        New = 1,
        [Description("The claim has been finished paying off")]
        Complete = 2,
        [Description("The claim has been disallowed")]
        Disallowed=3,
        [Description("The claim has been closed for reason(s) to be noted")]
        Closed = 4,
        [Description("The claim has been suspended pending reasons(investigation etc)")]
        Suspended= 5,
        [Description("The claim has been verified and is being processed")]
        Processing = 6,
        [Description("The claim is finalized and has begun payment")]
        Ongoing = 7
    }



    

    [DataContract]
    public enum Operation
    {
        [EnumMember]
        Verify,
        [EnumMember]
        Edit,
        [EnumMember]
        VerifyRemoval,
        [EnumMember]
        Cancel
    }


    public enum TrackingOperation
    {
        Assign,
        Reassign
    }


    public enum ReportCategory
    {
        [Description("Insured/Employment")]
        Insured_Employer = 1,

        [Description("Records/Contribution")]
        Records_Contribution = 2,

        [Description("Claims/Benefit")]
        Claims_Benefit = 3,

        [Description("Payment/Compliance")]
        Payment_Compliance = 4,

        [Description("Verification")]
        Verification = 5,

        [Description("Notification/Messages")]
        Notification_Messages = 6,

        [Description("Users/Inbox/Mywork/Tracking")]
        Tracking_users = 7,

        [Description("Ad hoc")]
        Ad_hoc = 8

    }

    public enum Insured_employer
    {
        [Description("List of Insured By Parish and Gender")]
        Insured_List_By_Parish_Gender = 1,
        [Description("List of Insured by Parish")]
        Insured_by_Parish = 2,
        [Description("List of Deceased by Parish")]
        Insured_Deceased_by_Parish = 3,
        [Description("Summary of Retired by Age/Gender")]
        Summary_of_Insured_Retirment_Age_Gender = 4
        
        
    }
    public enum Records_Contribution
    {
        [Description("List of Contribution by employer")]
        List_Contribution_By_Employer = 1,
    }


    public enum Ad_hoc
    {
         [Description("Active Employers")]
         Active_Employers = 1,

         [Description("Active Employers by Parish")]
         Active_Employers_by_Parish =2,

         [Description("Annual Returns Entered")]
         Annual_Returns_Entered =3,

         [Description("Annual Returns Per Year")]
         Annual_Returns_Per_Year = 4,

         [Description("Annual Return Rpt")]
         Annual_Return_Rpt = 5,

         [Description("Annual Return Summary")]
         Annual_Return_Summary = 6,

         [Description("Annual Return Type")]
         Annual_Return_Type = 7,   
   
         [Description("Annual Returns Head")]
         Annual_Returns_Head = 8,

         [Description("Application per parish")]    
         Application_per_parish = 9,

         [Description("Ars Back")]
         Ars_Back = 10        
    }
  
    
}
