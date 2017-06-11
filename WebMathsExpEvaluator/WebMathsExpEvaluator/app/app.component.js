"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var app_service_1 = require("./app.service");
var AppComponent = (function () {
    function AppComponent(expressionService) {
        this.expressionService = expressionService;
        this.indLoading = false;
        this.isComputed = false;
        this.isHistory = false;
        this.expressionUrl = 'api/expression';
    }
    AppComponent.prototype.getHistory = function () {
        var _this = this;
        this.isHistory = true;
        var obs = this.expressionService.getHistory(this.expressionUrl);
        obs.subscribe(function (res) {
            _this.history = res.json();
        }, function (err) {
            _this.history = err;
        });
    };
    ;
    AppComponent.prototype.sendValues = function () {
        var _this = this;
        this.indLoading = true;
        var obs = this.expressionService.create(this.expressionUrl, this.inputExpression);
        obs.subscribe(function (res) {
            _this.isComputed = true;
            _this.indLoading = false;
            _this.ComputedValue = res.json();
        }, function (err) {
            _this.indLoading = false;
            _this.isComputed = true;
            console.log(err);
            _this.ComputedValue = err;
        });
    };
    ;
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        selector: 'my-app',
        templateUrl: 'app.component.html',
        styleUrls: ['app.component.css'],
        moduleId: module.id,
        providers: [app_service_1.ExpressionService]
    }),
    __metadata("design:paramtypes", [app_service_1.ExpressionService])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map