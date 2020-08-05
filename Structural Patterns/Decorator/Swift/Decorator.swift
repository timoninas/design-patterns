import Foundation


protocol PCProtocol: class {
    func getPrice() -> Int
    func getConfiguration() -> String
}

class PC: PCProtocol {
    func getPrice() -> Int {
        return 500
    }
    
    func getConfiguration() -> String {
        return "PC"
    }
}

class PCDecorator: PCProtocol {
    private var PCtype: PCProtocol
    
    required init(pc: PCProtocol) {
        self.PCtype = pc
    }
    
    func getPrice() -> Int {
        return PCtype.getPrice()
    }
    
    func getConfiguration() -> String {
        return PCtype.getConfiguration()
    }
}

class PCTrx: PCDecorator {
    override func getPrice() -> Int {
        return super.getPrice() + 250
    }
    
    override func getConfiguration() -> String {
        return super.getConfiguration() + " with TRX"
    }
}

class PCWaterCooler: PCDecorator {
    override func getPrice() -> Int {
        return super.getPrice() + 100
    }
    
    override func getConfiguration() -> String {
        return super.getConfiguration() + " with Cooler"
    }
}

class PCRam: PCDecorator {
    override func getPrice() -> Int {
        return super.getPrice() + 150
    }
    
    override func getConfiguration() -> String {
        return super.getConfiguration() + " with 8GB Ram"
    }
}
