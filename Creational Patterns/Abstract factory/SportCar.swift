//
//  SportCar.swift
//  AbstractFactory
//
//  Created by Антон Тимонин on 13.02.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import Foundation

protocol SportCar {
    var name: String { get }
    
    func getInfo() -> String
}


class SportBWM: SportCar {
    var name: String = "BMW i8"
    
    func getInfo() -> String {
        return "\(name) has a max speed 315 k/h"
    }
}


class SportAudi: SportCar {
    var name: String = "Audi 8S"
    
    func getInfo() -> String {
        return "\(name) has a max speed 320 k/h"
    }
}


class SportMercedes: SportCar {
    var name: String = "Mercedes Benz"
    
    func getInfo() -> String {
        return "\(name) has a max speed 298 k/h"
    }
}
