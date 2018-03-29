webpackJsonp([2],{

/***/ 435:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
Object.defineProperty(__webpack_exports__, "__esModule", { value: true });
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "UserComponentModule", function() { return UserComponentModule; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(0);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_ionic_angular__ = __webpack_require__(27);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__user_component__ = __webpack_require__(448);
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};



var UserComponentModule = (function () {
    function UserComponentModule() {
    }
    return UserComponentModule;
}());
UserComponentModule = __decorate([
    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["L" /* NgModule */])({
        declarations: [
            __WEBPACK_IMPORTED_MODULE_2__user_component__["a" /* UserComponent */],
        ],
        imports: [
            __WEBPACK_IMPORTED_MODULE_1_ionic_angular__["f" /* IonicPageModule */].forChild(__WEBPACK_IMPORTED_MODULE_2__user_component__["a" /* UserComponent */]),
        ],
    })
], UserComponentModule);

//# sourceMappingURL=user.component.module.js.map

/***/ }),

/***/ 438:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return AppComponentBase; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0_ionic_angular__ = __webpack_require__(27);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1__kl_model_index__ = __webpack_require__(326);


var AppComponentBase = (function () {
    function AppComponentBase(injector) {
        var platform = injector.get(__WEBPACK_IMPORTED_MODULE_0_ionic_angular__["k" /* Platform */]);
        this.weChat = new __WEBPACK_IMPORTED_MODULE_1__kl_model_index__["d" /* WeChat */]();
        this.weChat.Code = platform.getQueryParam('code');
        this.weChat.State = platform.getQueryParam('state');
    }
    return AppComponentBase;
}());

//# sourceMappingURL=app-component-base.js.map

/***/ }),

/***/ 448:
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "a", function() { return UserComponent; });
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_0__angular_core__ = __webpack_require__(0);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_1_ionic_angular__ = __webpack_require__(27);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_2__app_component_base__ = __webpack_require__(438);
/* harmony import */ var __WEBPACK_IMPORTED_MODULE_3__kl_model_index__ = __webpack_require__(326);
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};




var UserComponent = (function (_super) {
    __extends(UserComponent, _super);
    function UserComponent(injector, navCtrl) {
        var _this = _super.call(this, injector) || this;
        _this.navCtrl = navCtrl;
        _this.user = new __WEBPACK_IMPORTED_MODULE_3__kl_model_index__["c" /* User */]();
        _this.user.Name = '唐德舟';
        _this.user.UserTypeName = '零售客户';
        return _this;
    }
    UserComponent.prototype.ionViewDidLoad = function () {
        console.log('ionViewDidLoad UserComponent');
    };
    return UserComponent;
}(__WEBPACK_IMPORTED_MODULE_2__app_component_base__["a" /* AppComponentBase */]));
UserComponent = __decorate([
    Object(__WEBPACK_IMPORTED_MODULE_1_ionic_angular__["e" /* IonicPage */])({
        name: 'user'
    }),
    Object(__WEBPACK_IMPORTED_MODULE_0__angular_core__["n" /* Component */])({
        selector: 'user-component',template:/*ion-inline-start:"D:\mygit\HCWeChat\ionic-wechat\src\pages\wechat\marketing\user\user.component.html"*/'<ion-header>\n\n    <ion-navbar no-border-bottom>\n\n        <ion-title>\n\n            用户中心\n\n        </ion-title>\n\n    </ion-navbar>\n\n</ion-header>\n\n<ion-content class="user-content-basic">\n\n    <ion-item class="photo" text-center no-border>\n\n        <ion-icon name="contact" color="primary" ></ion-icon>\n\n        <ion-img width="80" height="80" *ngIf="false" src=""></ion-img>\n\n    </ion-item>\n\n    <ion-item no-border>\n\n        <ion-label>用户名</ion-label>\n\n        <ion-label>{{user.Name}}</ion-label>\n\n    </ion-item>\n\n    <ion-item no-border>\n\n        <ion-label>用户类型</ion-label>\n\n        <ion-label>{{user.UserTypeName}}</ion-label>\n\n    </ion-item>\n\n    <ion-list no-border>\n\n        <ion-list-header>\n\n            营销活动\n\n        </ion-list-header>\n\n        <ion-item>\n\n            <ion-icon ios="ios-hammer" md="md-hammer" color="primary" item-start></ion-icon>\n\n            待审核\n\n            <ion-badge color="danger" item-end>10</ion-badge>\n\n        </ion-item>\n\n        <ion-item>\n\n            <ion-icon ios="ios-arrow-forward" md="md-arrow-forward" color="primary" item-start></ion-icon>\n\n            资料回传\n\n            <ion-note item-end>\n\n                无\n\n            </ion-note>\n\n        </ion-item>\n\n        <ion-item small>\n\n            <ion-icon md="md-reorder" ios="ios-reorder" color="primary" item-start></ion-icon>\n\n            已完成\n\n        </ion-item>\n\n    </ion-list>\n\n</ion-content>'/*ion-inline-end:"D:\mygit\HCWeChat\ionic-wechat\src\pages\wechat\marketing\user\user.component.html"*/,
    }),
    __metadata("design:paramtypes", [__WEBPACK_IMPORTED_MODULE_0__angular_core__["D" /* Injector */], __WEBPACK_IMPORTED_MODULE_1_ionic_angular__["i" /* NavController */]])
], UserComponent);

//# sourceMappingURL=user.component.js.map

/***/ })

});
//# sourceMappingURL=2.js.map