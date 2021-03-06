# Паттерн Одиночка

## Листинг 

#### Singleton.swift -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Singleton/Singleton.swift)



```Swift
// Первичные настройки приложения 
// единственные, также к настройкам 
// есть доступ из любого места приложения

class Settings {
    static let shared = Settings()
    
    var volumeMusic = 0.2
    var backgroundColor = UIColor.purple
    var pictureName = "kek.png"
    
    private init() {}
}

```

#### Singleton.cpp -> [Исходный код](https://github.com/timoninas/design-patterns/blob/master/Creational%20Patterns/Singleton/Singleton.cpp)

```C++
#include <iostream>
using namespace std;

class Singleton {
private:
    Singleton() {};
    Singleton(Singleton*);
    Singleton(const Singleton&);
    Singleton& operator=(Singleton&);
    
    static Singleton *instance;
    
public:
    static Singleton* get_instance() {
        if (instance == nullptr) {
            instance =  new Singleton;
        }
        return instance;
    }
};

int main(int argc, const char * argv[]) {
    cout << "Hello, World!\n";
    return 0;
}
```
