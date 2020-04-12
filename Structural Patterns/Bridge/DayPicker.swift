//
//  DayPicker.swift
//  Bridge
//
//  Created by Антон Тимонин on 12.04.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import Foundation
import UIKit


protocol PickerDayDataSource {
    func pickerDayCount(in pickerDay: UIPickerDayView) -> Int
    func pickerDayTitle(pickerDay: UIPickerDayView, indexPath: IndexPath) -> String
}

class UIPickerDayView: UIControl {
    
    var buttons: [UIButton] = []
    var stackview: UIStackView = UIStackView()
    
    var dataSource: PickerDayDataSource? {
        didSet {
            setupView()
        }
    }
    
//    override func layoutSubviews() {
//        super.layoutSubviews()
//        stackview.frame = bounds
//    }
    
    func setupView() {
        let count = dataSource?.pickerDayCount(in: self)
        
        for index in 0..<count! {
            let button = UIButton(type: .system)
            let indexPath = IndexPath(row: index, section: 0)
            let title = dataSource?.pickerDayTitle(pickerDay: self, indexPath: indexPath)
            button.setTitle(title, for: .normal)
            button.setTitleColor(#colorLiteral(red: 0.5236918926, green: 0.9591721892, blue: 1, alpha: 1), for: .normal)
            button.setTitleColor(#colorLiteral(red: 0.2073595822, green: 0.6023685336, blue: 0.8753715158, alpha: 1), for: .normal)
            button.tag = index
            button.addTarget(self, action: #selector(selectedButton(sender:)), for: .touchUpInside)
            buttons.append(button)
        }
        
        stackview = UIStackView(arrangedSubviews: buttons)
        self.addSubview(stackview)
        
        stackview.spacing = 8
        stackview.axis = .horizontal
        stackview.alignment = .center
        stackview.distribution = .fillEqually
        stackview.frame = bounds
    }
    
    @objc func selectedButton(sender: UIButton) {
        print(#function)
        for index in 0..<buttons.count {
            buttons[index].isSelected = false
        }
        
        buttons[sender.tag].isSelected = true
    }
}

