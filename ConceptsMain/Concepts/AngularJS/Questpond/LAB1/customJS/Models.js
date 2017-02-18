var Customer = function () {

    this.cname = "Vaibhav";
    this.cid = "1001";
    this.CustomerBackgroundColor = "Blue";
    this.Amount = "100";

    this.CalculateDiscount = function () {
        alert("10% Discount");
        return 10;
    };
};

var GoldCustomer = function () {

    this.cname = "Vaibhav";
    this.cid = "1001";
    this.CustomerBackgroundColor = "Blue";
    this.Amount = "100";

    this.CalculateDiscount = function () {
        alert("20% Discount");
        return 20;
    };
};

var Factory = function () {

    return {
        CreateCustObject: function (type) {
            switch (type) {
                case 1: return new Customer(); break;
                default: return new GoldCustomer(); break;
            }
            
        }

    }

};