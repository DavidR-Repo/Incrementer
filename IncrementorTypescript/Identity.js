"use strict";
/*
 *000 - ZZZ Incrementer Original Concept and control flow by David Russell done in C#
 * https://github.com/DavidR-Repo/Incrementer
 * Port and translation for TypeScript
 */
Object.defineProperty(exports, "__esModule", { value: true });
class Identity {
    constructor(newId) {
        this.toString = () => {
            return `${this.value[0]}${this.value[1]}${this.value[2]}`;
        };
        if (newId.length > 3) {
            throw Error("Invalid Id Length");
        }
        if (!this.isValidChar(newId)) {
            throw Error(`Invalid Id ${newId}`);
        }
        this.value = new Array();
        this.value.push(newId[0]);
        this.value.push(newId[1]);
        this.value.push(newId[2]);
        this.isNumber = new Array();
        this.isNumber.push(false);
        this.isNumber.push(false);
        this.isNumber.push(false);
        if (this.value[0] >= "9") {
            this.isNumber[0] = false;
        }
        if (this.value[0] >= "Z" && this.value[1] >= "9") {
            this.isNumber[1] = false;
        }
        if (this.value[0] === "Z" && this.value[1] === "Z" && this.value[1] >= "9") {
            this.isNumber[2] = false;
        }
    }
    increment(pos = 2) {
        if (pos > 2 || pos < 0) {
            throw new Error("Invalid Position");
        }
        if (this.isNumber[pos]) {
            this.numericIncrement(pos);
        }
        else {
            this.alphaIncrement(pos);
        }
        if (this.value[0] === "Z" && this.value[1] === "Z" && this.value[2] === "9") {
            this.isNumber[2] = false;
        }
        else if (this.value[0] === "Z" && this.value[1] === "9") {
            this.isNumber[1] = false;
        }
        else if (this.value[0] === "9") {
            this.isNumber[0] = false;
        }
    }
    alphaIncrement(pos) {
        if (this.value[pos] === "9") {
            this.value[pos] = "A";
            return;
        }
        else if (this.value[pos] < "Z") {
            let char = this.value[pos].charCodeAt(0);
            char++;
            this.value[pos] = String.fromCharCode(char);
            return;
        }
        throw new Error("Invalid position: cannot increment a 'Z'");
    }
    numericIncrement(pos) {
        if (this.value[pos] < "9") {
            let char = parseInt(this.value[pos]);
            char++;
            this.value[pos] = char.toString();
            return;
        }
        else if (this.value[pos] === "9" && !this.isNumber[pos]) {
            this.value[pos] = "A";
            return;
        }
        this.value[pos] = "0";
        this.increment(pos - 1);
    }
    set(newId) {
        if (newId.length > 3)
            throw new Error("In Set: invalid id length");
        if (!this.isValidChar(newId))
            throw new Error(`in Set(): invalid id ${newId}`);
        this.value[0] = newId[0];
        this.value[1] = newId[1];
        this.value[2] = newId[2];
    }
    isValidChar(value) {
        for (let i = 0; i < value.length; i++) {
            if (value[i] < "0" ||
                value[i] > "Z" ||
                (value[i] > "9" && value[i] < "A"))
                return false;
        }
        return true;
    }
}
exports.Identity = Identity;
//# sourceMappingURL=Identity.js.map