//
//  Car.swift
//  AbstractFactory
//
//  Created by Антон Тимонин on 13.02.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import Foundation

protocol CompactCar {
    var name: String { get }
    
    func slowRide() -> String
}


class CompactBMW: CompactCar {
    var name: String = "BMW X5"
    
    func slowRide() -> String {
        return "Wa are drive slowly in a \(name)"
    }
}


class CompactAudi: CompactCar {
    var name: String = "Audi TT"
    
    func slowRide() -> String {
        return "Wa are drive slowly in a \(name)"
    }
}


class CompactMercedes: CompactCar {
    var name: String = "Mercdec LL"
    
    func slowRide() -> String {
        return "Wa are drive slowly in a \(name)"
    }
}
