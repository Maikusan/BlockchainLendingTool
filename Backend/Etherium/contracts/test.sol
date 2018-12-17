contract test {

    mapping (bytes32=>Rental[]) public rentals;

    struct Rental{
        address landlord;
        address tenant;
        uint depositeAmount;
        uint rentalPrice;
        ///mapping(address => uint256) depositeAmount;
        ///mapping(address => uint256) rentalPrice;
        uint endtime;
        uint itemId;
    }

    function StoreRental(bytes32 key, address landlord, uint depositeAmount, uint rentalPrice, uint endtime, uint itemId) returns (bool success) {
       Rental memory rent = Rental(landlord, msg.sender, depositeAmount, rentalPrice, endtime, itemId);      
       rentals[key].push(rent);
       ///AddRentalCost(depositeAmount, rentalPrice);
       return true;
    }

    ///function AddRentalCost(uint id, uint testDepositeAmount, uint testRentalPrice) public payable{
       ///rentals[id].depositeAmount[msg.sender] += testDepositeAmount;
       ///rentals[id].rentalPrice[msg.sender] += testRentalPrice;
    ///}
}