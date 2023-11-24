namespace Prod_Manger.Models.Domain
{
    public class ClientViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public int Phone { get; set; }
        public string? County { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? StreetNo { get; set; }
        public string? Building { get; set; }
        public string? BuildingNo { get; set; }
        public string? Floor { get; set; }
        public string? Ap { get; set; }
        public string? PersonType { get; set; }
        public int CNP { get; set; }
        public int CUI { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? DeliveryCounty { get; set; }
        public string? DeliveryCity { get; set; }
        public string? DeliveryStreet { get; set; }
        public string? DeliveryStreetNo { get; set; }
        public string? DeliveryBuilding { get; set; }
        public string? DeliveryBuildingNo { get; set; }
        public string? DeliveryFloor { get; set; }
        public string? DeliveryAp { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
