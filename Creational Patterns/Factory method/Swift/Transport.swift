//
//  Transport.swift
//  Factory
//
//  Created by Антон Тимонин on 10.02.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import Foundation

enum Terrain {
    case air, ground, water, underwater
}

protocol Transport {
    var name: String { get }
    var type: Terrain { get }
    
    func startMove()
    func stopMove()
}
