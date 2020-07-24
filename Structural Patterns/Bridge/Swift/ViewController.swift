//
//  ViewController.swift
//  Bridge
//
//  Created by Антон Тимонин on 12.04.2020.
//  Copyright © 2020 Антон Тимонин. All rights reserved.
//

import UIKit
import Alamofire
import SwiftyJSON
import CoreLocation

class ViewController: UIViewController {

    let daysOfWeek = ["Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"]
    
    let apiKey = "e6185ce3a9714666c6d2ec99eb7f4b74"
    let lat = 11.344533
    let lon = 104.33322
    
    @IBOutlet weak var pickerDay: UIPickerDayView!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        pickerDay.dataSource = self
//        let request = Alamofire.Request
    }
}

extension ViewController: PickerDayDataSource {
    func pickerDayCount(in pickerDay: UIPickerDayView) -> Int {
        daysOfWeek.count
    }
    
    func pickerDayTitle(pickerDay: UIPickerDayView, indexPath: IndexPath) -> String {
        daysOfWeek[indexPath.row]
    }
}

