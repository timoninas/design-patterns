import UIKit

// Flyweight extension
// Легковес расширение

extension UIColor {
    static var sameColors: [String: UIColor] = [:]
    
    class func getRGBA(red:   CGFloat,
                       green: CGFloat,
                       blue:  CGFloat,
                       alpha: CGFloat) -> UIColor {
        
        let key = "\(red)\(green)\(blue)\(alpha)"
        
        if let color = self.sameColors[key] {
            return color
        }
        
        let color = UIColor(red:   red,
                            green: green,
                            blue:  blue,
                            alpha: alpha)
        self.sameColors[key] = color
        
        return color
    }
}

func main() {
    
    // Flyweight color generator
    var a = UIColor.getRGBA(red: 1, green: 1, blue: 0, alpha: 0.5)
    var b = UIColor.getRGBA(red: 1, green: 1, blue: 0, alpha: 0.5)
    
    print(a === b) // Addres comparation
    
    a = UIColor(red: 1, green: 1, blue: 0, alpha: 0.5)
    b = UIColor(red: 1, green: 1, blue: 0, alpha: 0.5)
    
    print(a === b) // Addres comparation
}

main()
