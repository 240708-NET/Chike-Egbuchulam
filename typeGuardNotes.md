# Type Guards

A type guard is some expression that performs a runtime check that guarantees the type in some scope.
They enhance type safety by checking the varible types using typeof, instanceof, or custom type guard functions.

Source: `https://www.typescriptlang.org/docs/handbook/advanced-types.html`

Without type guards, JavaScript does not allow for property accessors
``` javascript

    // Problem
    let pet = getSmallPet();  

    // You can use the 'in' operator to check
    if ("swim" in pet) {
    pet.swim();
    }
    // However, you cannot use property access
    if (pet.fly) {
    //Errors:
    //Property 'fly' does not exist on type 'Fish | Bird'.
    //Property 'fly' does not exist on type 'Fish'.
    pet.fly();
    //Errors:
    //Property 'fly' does not exist on type 'Fish | Bird'.
    //Property 'fly' does not exist on type 'Fish'.
    }

    //-----------------------------------------------------

    // Solution - using a User-Defined Type Guard
    function isFish(pet: Fish | Bird): pet is Fish {
        return (pet as Fish).swim !== undefined;
    }

    // Now, calls to both 'swim' and 'fly' are okay
    let pet = getSmallPet();
    
    if (isFish(pet)) {
    pet.swim();
    } else {
    pet.fly();
    }
    //TypeScript also knows that in the context of this if-else, if a pet cannot swim, then it is not a Fish, so it must be a Bird
```

# Built-in Type Guards

- instanceOF: built int type guard that checks if a value is an instance of a class

    ``` javascript 
    objectVariable instanceof ClassName;
    ```

- typeof :used to determine type of variable. However has a limited scope can only recognize
    - boolean
    - string
    - bigint
    - symbol
    - undefined
    - function
    - number

    ``` javascript 
    var obj = 2;
    obj typeof number;
    ```
