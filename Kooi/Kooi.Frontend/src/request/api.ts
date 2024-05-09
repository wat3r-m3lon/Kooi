import service from ".";
// tooltip
export function getTooltipsList() {
    return service({
        url: "/tooltips",
        method: "get"
    })
}
export function updateTooltipById(id: any, tooltip: any) {
    return service({
        url: `/tooltip/${id}`,
        method: "put",
        data: tooltip
    })
}
export function getAlignmentsList(){
    return service({
        url: "/alignments",
        method: "get"
    })
}
export function getSidesList(){
    return service({
        url: "/sides",
        method: "get"
    })
}
export function getIconsList(){
    return service({
        url: "/icons",
        method: "get"
    })
}