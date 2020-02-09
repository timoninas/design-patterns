//
//  Factory.swift
//  Factory
//
//  Created by Антон Тимонин on 10.02.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import Foundation

enum TransportType {
    case car, helicopter, ship
}

class FactoryTransport {
    static let shared = FactoryTransport()
    
    func createTransport(value: TransportType) -> Transport {
        switch value {
        case .car: return Car()
        case .helicopter: return Helicopter()
        case .ship: return Ship()
        }
    }
}
