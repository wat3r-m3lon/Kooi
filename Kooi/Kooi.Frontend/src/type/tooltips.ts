export interface TooltipsListInt {
    id: string,
    title: string,
    elementIdentifier: string,
    iconId: string,
    iconSideId: string,
    iconAlignId: string,
    routeId: string
}
interface SidesListInt {
    sideId: number
    sideName: string
}
interface AlignmentsListInt {
    alignId: number
    alignName: string
}
interface SelectDataInt {
    id: string,
}
interface SingleInt {
    id: string,
    title: string,
    elementIdentifier: string,
    iconId: string,
    iconSideId: string,
    iconAlignId: string,
    routeId: string
}
export class InitData {
    selectData: SelectDataInt = {
        id: "",
    }
    list: TooltipsListInt[] = []
    sideList: SidesListInt[] = []
    alignList: AlignmentsListInt[] = []
    show = false
    reload = false
    current: SingleInt = {
        title: "",
        elementIdentifier: "",
        iconId: "",
        iconSideId: "",
        iconAlignId: "",
        routeId: "",
        id: ""
    }
} 
