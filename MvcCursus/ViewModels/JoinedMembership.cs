namespace MvcCursus.ViewModels
{
    public class JoinedMembership
    {
        // Dit is geen Model (want staat niet op deze manier in de DB)
        // Dit is een ViewModel want deze class wordt gebruikt specifiek voor het scherm met Memberships



        public int MembershipID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}