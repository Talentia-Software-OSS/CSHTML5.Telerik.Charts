declare namespace kendo {
    class Class {
        static fn: Class;
        static extend(prototype: Object): Class;
    }

    class Observable extends Class {
        static fn: Observable;
        static extend(prototype: Object): Observable;

        init(...args: any[]): void;

        bind(eventName: string, handler: Function): Observable;
        bind(events: string[], handler: Function): Observable;
        bind(events: string[], handlers: { [eventName: string]: Function }): Observable;

        one(eventName: string, handler: Function): Observable;
        one(events: string[], handler: Function): Observable;
        one(events: string[], handlers: { [eventName: string]: Function }): Observable;

        first(eventName: string, handler: Function): Observable;
        first(events: string[], handler: Function): Observable;
        first(events: string[], handlers: { [eventName: string]: Function }): Observable;

        trigger(eventName: string, e?: any): boolean;
        unbind(eventName: string, handler?: any): Observable;
    }
}

declare namespace kendo.drawing {
    class Element extends kendo.Class {


        options: ElementOptions;

        parent: kendo.drawing.Group;

        constructor(options?: ElementOptions);


        bbox(): kendo.geometry.Rect;
        clip(): kendo.drawing.Path;
        clip(clip: kendo.drawing.Path): void;
        clippedBBox(): kendo.geometry.Rect;
        containsPoint(point: kendo.geometry.Point): boolean;
        opacity(): number;
        opacity(opacity: number): void;
        transform(): kendo.geometry.Transformation;
        transform(transform: kendo.geometry.Transformation): void;
        visible(): boolean;
        visible(visible: boolean): void;

    }

    interface ElementOptions {
        name?: string;
        clip?: kendo.drawing.Path;
        cursor?: string;
        opacity?: number;
        transform?: kendo.geometry.Transformation;
        visible?: boolean;
    }

    interface FillOptions {



        color?: string;
        opacity?: number;




    }

    class Group extends kendo.drawing.Element {


        options: GroupOptions;

        children: any;

        constructor(options?: GroupOptions);


        append(element: kendo.drawing.Element): void;
        clear(): void;
        clip(): kendo.drawing.Path;
        clip(clip: kendo.drawing.Path): void;
        clippedBBox(): kendo.geometry.Rect;
        containsPoint(point: kendo.geometry.Point): boolean;
        insert(position: number, element: kendo.drawing.Element): void;
        opacity(): number;
        opacity(opacity: number): void;
        remove(element: kendo.drawing.Element): void;
        removeAt(index: number): void;
        visible(): boolean;
        visible(visible: boolean): void;

    }

    interface GroupOptions {
        name?: string;
        clip?: kendo.drawing.Path;
        cursor?: string;
        opacity?: number;
        pdf?: kendo.drawing.PDFOptions;
        tooltip?: kendo.drawing.TooltipOptions;
        transform?: kendo.geometry.Transformation;
        visible?: boolean;
    }

    class MultiPath extends kendo.drawing.Element {


        options: MultiPathOptions;

        paths: any;

        constructor(options?: MultiPathOptions);


        bbox(): kendo.geometry.Rect;
        clip(): kendo.drawing.Path;
        clip(clip: kendo.drawing.Path): void;
        clippedBBox(): kendo.geometry.Rect;
        close(): kendo.drawing.MultiPath;
        containsPoint(point: kendo.geometry.Point): boolean;
        curveTo(controlOut: any, controlIn: any, endPoint: any): kendo.drawing.MultiPath;
        curveTo(controlOut: any, controlIn: any, endPoint: kendo.geometry.Point): kendo.drawing.MultiPath;
        curveTo(controlOut: any, controlIn: kendo.geometry.Point, endPoint: any): kendo.drawing.MultiPath;
        curveTo(controlOut: any, controlIn: kendo.geometry.Point, endPoint: kendo.geometry.Point): kendo.drawing.MultiPath;
        curveTo(controlOut: kendo.geometry.Point, controlIn: any, endPoint: any): kendo.drawing.MultiPath;
        curveTo(controlOut: kendo.geometry.Point, controlIn: any, endPoint: kendo.geometry.Point): kendo.drawing.MultiPath;
        curveTo(controlOut: kendo.geometry.Point, controlIn: kendo.geometry.Point, endPoint: any): kendo.drawing.MultiPath;
        curveTo(controlOut: kendo.geometry.Point, controlIn: kendo.geometry.Point, endPoint: kendo.geometry.Point): kendo.drawing.MultiPath;
        fill(color: string, opacity?: number): kendo.drawing.MultiPath;
        lineTo(x: number, y?: number): kendo.drawing.MultiPath;
        lineTo(x: any, y?: number): kendo.drawing.MultiPath;
        lineTo(x: kendo.geometry.Point, y?: number): kendo.drawing.MultiPath;
        moveTo(x: number, y?: number): kendo.drawing.MultiPath;
        moveTo(x: any, y?: number): kendo.drawing.MultiPath;
        moveTo(x: kendo.geometry.Point, y?: number): kendo.drawing.MultiPath;
        opacity(): number;
        opacity(opacity: number): void;
        stroke(color: string, width?: number, opacity?: number): kendo.drawing.MultiPath;
        transform(): kendo.geometry.Transformation;
        transform(transform: kendo.geometry.Transformation): void;
        visible(): boolean;
        visible(visible: boolean): void;

    }

    interface MultiPathOptions {
        name?: string;
        clip?: kendo.drawing.Path;
        cursor?: string;
        fill?: kendo.drawing.FillOptions;
        opacity?: number;
        stroke?: kendo.drawing.StrokeOptions;
        tooltip?: kendo.drawing.TooltipOptions;
        transform?: kendo.geometry.Transformation;
        visible?: boolean;
    }

    interface PDFOptions {



        creator?: string;
        date?: Date;
        imgDPI?: number;
        keywords?: string;
        landscape?: boolean;
        margin?: any;
        paperSize?: any;
        subject?: string;
        title?: string;




    }

    class Path extends kendo.drawing.Element {


        options: PathOptions;

        segments: any;

        constructor(options?: PathOptions);

        static fromArc(arc: kendo.geometry.Arc, options?: any): kendo.drawing.Path;
        static fromPoints(points: any, options?: any): kendo.drawing.Path;
        static fromRect(rect: kendo.geometry.Rect, options?: any): kendo.drawing.Path;
        static parse(svgPath: string, options?: any): kendo.drawing.MultiPath;

        bbox(): kendo.geometry.Rect;
        clip(): kendo.drawing.Path;
        clip(clip: kendo.drawing.Path): void;
        clippedBBox(): kendo.geometry.Rect;
        close(): kendo.drawing.Path;
        containsPoint(point: kendo.geometry.Point): boolean;
        curveTo(controlOut: any, controlIn: any, endPoint: any): kendo.drawing.Path;
        curveTo(controlOut: any, controlIn: any, endPoint: kendo.geometry.Point): kendo.drawing.Path;
        curveTo(controlOut: any, controlIn: kendo.geometry.Point, endPoint: any): kendo.drawing.Path;
        curveTo(controlOut: any, controlIn: kendo.geometry.Point, endPoint: kendo.geometry.Point): kendo.drawing.Path;
        curveTo(controlOut: kendo.geometry.Point, controlIn: any, endPoint: any): kendo.drawing.Path;
        curveTo(controlOut: kendo.geometry.Point, controlIn: any, endPoint: kendo.geometry.Point): kendo.drawing.Path;
        curveTo(controlOut: kendo.geometry.Point, controlIn: kendo.geometry.Point, endPoint: any): kendo.drawing.Path;
        curveTo(controlOut: kendo.geometry.Point, controlIn: kendo.geometry.Point, endPoint: kendo.geometry.Point): kendo.drawing.Path;
        fill(color: string, opacity?: number): kendo.drawing.Path;
        lineTo(x: number, y?: number): kendo.drawing.Path;
        lineTo(x: any, y?: number): kendo.drawing.Path;
        lineTo(x: kendo.geometry.Point, y?: number): kendo.drawing.Path;
        moveTo(x: number, y?: number): kendo.drawing.Path;
        moveTo(x: any, y?: number): kendo.drawing.Path;
        moveTo(x: kendo.geometry.Point, y?: number): kendo.drawing.Path;
        opacity(): number;
        opacity(opacity: number): void;
        stroke(color: string, width?: number, opacity?: number): kendo.drawing.Path;
        transform(): kendo.geometry.Transformation;
        transform(transform: kendo.geometry.Transformation): void;
        visible(): boolean;
        visible(visible: boolean): void;

    }

    interface PathOptions {
        name?: string;
        clip?: kendo.drawing.Path;
        cursor?: string;
        fill?: kendo.drawing.FillOptions;
        opacity?: number;
        stroke?: kendo.drawing.StrokeOptions;
        tooltip?: kendo.drawing.TooltipOptions;
        transform?: kendo.geometry.Transformation;
        visible?: boolean;
    }

    interface StrokeOptions {



        color?: string;
        dashType?: string;
        lineCap?: string;
        lineJoin?: string;
        opacity?: number;
        width?: number;




    }

    class Surface extends kendo.Observable {
        options: SurfaceOptions;

        constructor(options?: SurfaceOptions);

        static create(element: JQuery, options?: any): kendo.drawing.Surface;
        static create(element: Element, options?: any): kendo.drawing.Surface;

        element: JQuery;

        clear(): void;
        draw(element: kendo.drawing.Element): void;
        eventTarget(e: any): kendo.drawing.Element;
        hideTooltip(): void;
        resize(force?: boolean): void;
        showTooltip(element: kendo.drawing.Element, options?: any): void;

    }

    interface SurfaceTooltipAnimationClose {
        effects?: string;
        duration?: number;
    }

    interface SurfaceTooltipAnimationOpen {
        effects?: string;
        duration?: number;
    }

    interface SurfaceTooltipAnimation {
        close?: SurfaceTooltipAnimationClose;
        open?: SurfaceTooltipAnimationOpen;
    }

    interface SurfaceTooltip {
        animation?: boolean | SurfaceTooltipAnimation;
        appendTo?: string | JQuery;
    }

    interface SurfaceOptions {
        name?: string;
        type?: string;
        height?: string;
        width?: string;
        tooltip?: SurfaceTooltip;
        click?(e: SurfaceClickEvent): void;
        mouseenter?(e: SurfaceMouseenterEvent): void;
        mouseleave?(e: SurfaceMouseleaveEvent): void;
        tooltipClose?(e: SurfaceTooltipCloseEvent): void;
        tooltipOpen?(e: SurfaceTooltipOpenEvent): void;
    }

    interface SurfaceEvent {
        sender: Surface;
        preventDefault: Function;
        isDefaultPrevented(): boolean;
    }

    interface SurfaceClickEvent extends SurfaceEvent {
        element?: kendo.drawing.Element;
        originalEvent?: any;
    }

    interface SurfaceMouseenterEvent extends SurfaceEvent {
        element?: kendo.drawing.Element;
        originalEvent?: any;
    }

    interface SurfaceMouseleaveEvent extends SurfaceEvent {
        element?: kendo.drawing.Element;
        originalEvent?: any;
    }

    interface SurfaceTooltipCloseEvent extends SurfaceEvent {
        element?: kendo.drawing.Element;
        target?: kendo.drawing.Element;
    }

    interface SurfaceTooltipOpenEvent extends SurfaceEvent {
        element?: kendo.drawing.Element;
        target?: kendo.drawing.Element;
    }

    interface TooltipOptions {



        autoHide?: boolean;
        content?: string | Function;
        position?: string;
        height?: number | string;
        hideDelay?: number;
        offset?: number;
        shared?: boolean;
        showAfter?: number;
        showOn?: string;
        width?: number | string;




    }
}

declare namespace kendo.geometry {
    class Arc extends Observable {


        options: ArcOptions;

        anticlockwise: boolean;
        center: kendo.geometry.Point;
        endAngle: number;
        radiusX: number;
        radiusY: number;
        startAngle: number;

        constructor(center: any | kendo.geometry.Point, options?: ArcOptions);


        bbox(matrix: kendo.geometry.Matrix): kendo.geometry.Rect;
        getAnticlockwise(): boolean;
        getCenter(): kendo.geometry.Point;
        getEndAngle(): number;
        getRadiusX(): number;
        getRadiusY(): number;
        getStartAngle(): number;
        pointAt(angle: number): kendo.geometry.Point;
        setAnticlockwise(value: boolean): kendo.geometry.Arc;
        setCenter(value: kendo.geometry.Point): kendo.geometry.Arc;
        setEndAngle(value: number): kendo.geometry.Arc;
        setRadiusX(value: number): kendo.geometry.Arc;
        setRadiusY(value: number): kendo.geometry.Arc;
        setStartAngle(value: number): kendo.geometry.Arc;

    }

    interface ArcOptions {
        name?: string;
    }

    class Matrix extends Observable {


        options: MatrixOptions;

        a: number;
        b: number;
        c: number;
        d: number;
        e: number;
        f: number;


        static rotate(angle: number, x: number, y: number): kendo.geometry.Matrix;
        static scale(scaleX: number, scaleY: number): kendo.geometry.Matrix;
        static translate(x: number, y: number): kendo.geometry.Matrix;
        static unit(): kendo.geometry.Matrix;

        clone(): kendo.geometry.Matrix;
        equals(other: kendo.geometry.Matrix): boolean;
        round(digits: number): kendo.geometry.Matrix;
        multiplyCopy(matrix: kendo.geometry.Matrix): kendo.geometry.Matrix;
        toArray(digits: number): any;
        toString(digits: number, separator: string): string;

    }

    interface MatrixOptions {
        name?: string;
    }

    class Point extends Observable {


        options: PointOptions;

        x: number;
        y: number;

        constructor(x: number, y: number);

        static create(x: number, y: number): kendo.geometry.Point;
        static create(x: any, y: number): kendo.geometry.Point;
        static create(x: kendo.geometry.Point, y: number): kendo.geometry.Point;
        static min(): kendo.geometry.Point;
        static max(): kendo.geometry.Point;
        static minPoint(): kendo.geometry.Point;
        static maxPoint(): kendo.geometry.Point;

        clone(): kendo.geometry.Point;
        distanceTo(point: kendo.geometry.Point): number;
        equals(other: kendo.geometry.Point): boolean;
        getX(): number;
        getY(): number;
        move(x: number, y: number): kendo.geometry.Point;
        rotate(angle: number, center: kendo.geometry.Point): kendo.geometry.Point;
        rotate(angle: number, center: any): kendo.geometry.Point;
        round(digits: number): kendo.geometry.Point;
        scale(scaleX: number, scaleY: number): kendo.geometry.Point;
        scaleCopy(scaleX: number, scaleY: number): kendo.geometry.Point;
        setX(value: number): kendo.geometry.Point;
        setY(value: number): kendo.geometry.Point;
        toArray(digits: number): any;
        toString(digits: number, separator: string): string;
        transform(tansformation: kendo.geometry.Transformation): kendo.geometry.Point;
        transformCopy(tansformation: kendo.geometry.Transformation): kendo.geometry.Point;
        translate(dx: number, dy: number): kendo.geometry.Point;
        translateWith(vector: kendo.geometry.Point): kendo.geometry.Point;
        translateWith(vector: any): kendo.geometry.Point;

    }

    interface PointOptions {
        name?: string;
    }

    class Rect extends Observable {


        options: RectOptions;

        origin: kendo.geometry.Point;
        size: kendo.geometry.Size;

        constructor(origin: kendo.geometry.Point | any, size: kendo.geometry.Size | any);

        static fromPoints(pointA: kendo.geometry.Point, pointB: kendo.geometry.Point): kendo.geometry.Rect;
        static union(rectA: kendo.geometry.Rect, rectB: kendo.geometry.Rect): kendo.geometry.Rect;

        bbox(matrix: kendo.geometry.Matrix): kendo.geometry.Rect;
        bottomLeft(): kendo.geometry.Point;
        bottomRight(): kendo.geometry.Point;
        center(): kendo.geometry.Point;
        clone(): kendo.geometry.Rect;
        equals(other: kendo.geometry.Rect): boolean;
        getOrigin(): kendo.geometry.Point;
        getSize(): kendo.geometry.Size;
        height(): number;
        setOrigin(value: kendo.geometry.Point): kendo.geometry.Rect;
        setOrigin(value: any): kendo.geometry.Rect;
        setSize(value: kendo.geometry.Size): kendo.geometry.Rect;
        setSize(value: any): kendo.geometry.Rect;
        topLeft(): kendo.geometry.Point;
        topRight(): kendo.geometry.Point;
        width(): number;

    }

    interface RectOptions {
        name?: string;
    }

    class Size extends Observable {


        options: SizeOptions;

        width: number;
        height: number;


        static create(width: number, height: number): kendo.geometry.Size;
        static create(width: any, height: number): kendo.geometry.Size;
        static create(width: kendo.geometry.Size, height: number): kendo.geometry.Size;

        clone(): kendo.geometry.Size;
        equals(other: kendo.geometry.Size): boolean;
        getWidth(): number;
        getHeight(): number;
        setWidth(value: number): kendo.geometry.Size;
        setHeight(value: number): kendo.geometry.Size;

    }

    interface SizeOptions {
        name?: string;
    }

    class Transformation extends Observable {


        options: TransformationOptions;




        clone(): kendo.geometry.Transformation;
        equals(other: kendo.geometry.Transformation): boolean;
        matrix(): kendo.geometry.Matrix;
        multiply(transformation: kendo.geometry.Transformation): kendo.geometry.Transformation;
        rotate(angle: number, center: any): kendo.geometry.Transformation;
        rotate(angle: number, center: kendo.geometry.Point): kendo.geometry.Transformation;
        scale(scaleX: number, scaleY: number): kendo.geometry.Transformation;
        translate(x: number, y: number): kendo.geometry.Transformation;

    }

    interface TransformationOptions {
        name?: string;
    }

}

declare namespace kendo.data {

    class BindingTarget {
        target: any;
        options: any;
        source: any;
    }

    class ObservableObject extends Observable {
        constructor(value?: any);
        uid: string;
        init(value?: any): void;
        get(name: string): any;
        parent(): ObservableObject;
        set(name: string, value: any): void;
        toJSON(): Object;
    }

    class Model extends ObservableObject {
        static idField: string;
        static fields: DataSourceSchemaModelFields;

        idField: string;
        _defaultId: any;
        fields: DataSourceSchemaModelFields;
        defaults: {
            [field: string]: any;
        };
        id: any;
        dirty: boolean;

        static define(options: DataSourceSchemaModelWithFieldsObject): typeof Model;
        static define(options: DataSourceSchemaModelWithFieldsArray): typeof Model;

        constructor(data?: any);
        init(data?: any): void;
        accept(data?: any): void;
        editable(field: string): boolean;
        isNew(): boolean;
    }

    interface DataSourceTransport {
        create?: string | DataSourceTransportCreate/* | ((options: DataSourceTransportOptions) => void)*/;
        destroy?: string | DataSourceTransportDestroy/* | ((options: DataSourceTransportOptions) => void)*/;
        push?: Function;
        submit?: Function;
        read?: string | DataSourceTransportRead/* | ((options: DataSourceTransportOptions) => void)*/;
        signalr?: DataSourceTransportSignalr /*| ((options: DataSourceTransportOptions) => void)*/;
        update?: string | DataSourceTransportUpdate/* | ((options: DataSourceTransportOptions) => void)*/;
        parameterMap?(data: DataSourceTransportParameterMapData, type: string): any;
    }

    interface DataSourceTransportSignalrClient {
        create?: string;
        destroy?: string;
        read?: string;
        update?: string;
    }

    interface DataSourceTransportSignalrServer {
        create?: string;
        destroy?: string;
        read?: string;
        update?: string;
    }

    interface DataSourceTransportSignalr {
        client?: DataSourceTransportSignalrClient;
        hub?: any;
        promise?: any;
        server?: DataSourceTransportSignalrServer;
    }

    interface DataSourceParameterMapDataAggregate {
        field?: string;
        aggregate?: string;
    }

    interface DataSourceParameterMapDataGroup {
        aggregate?: DataSourceParameterMapDataAggregate[];
        field?: string;
        dir?: string;
    }

    interface DataSourceParameterMapDataFilter {
        field?: string;
        filters?: DataSourceParameterMapDataFilter[];
        logic?: string;
        operator?: string;
        value?: any;
    }

    interface DataSourceParameterMapDataSort {
        field?: string;
        dir?: string;
    }

    interface DataSourceTransportParameterMapData {
        aggregate?: DataSourceParameterMapDataAggregate[];
        group?: DataSourceParameterMapDataGroup[];
        filter?: DataSourceParameterMapDataFilter;
        models?: Model[];
        page?: number;
        pageSize?: number;
        skip?: number;
        sort?: DataSourceParameterMapDataSort[];
        take?: number;
    }

    interface DataSourceSchemaModel {
        id?: string;
        fields?: any;
        [index: string]: any;
    }

    interface DataSourceSchemaModelWithFieldsArray extends DataSourceSchemaModel {
        fields?: DataSourceSchemaModelField[];
    }

    interface DataSourceSchemaModelWithFieldsObject extends DataSourceSchemaModel {
        fields?: DataSourceSchemaModelFields;
    }

    interface DataSourceSchemaModelFields {
        [index: string]: DataSourceSchemaModelField;
    }

    interface DataSourceSchemaModelField {
        field?: string;
        from?: string;
        defaultValue?: any;
        editable?: boolean;
        nullable?: boolean;
        parse?: Function;
        type?: string;
        validation?: DataSourceSchemaModelFieldValidation;
    }

    interface DataSourceSchemaModelFieldValidation {
        required?: boolean;
        min?: any;
        max?: any;
        minLength?: any;
        maxLength?: any;
        [rule: string]: any;
    }

    class ObservableArray extends Observable {
        length: number;
        [index: number]: any;

        constructor(array: any[]);
        init(array: any[]): void;
        empty(): void;
        every(callback: (item: Object, index: number, source: ObservableArray) => boolean): boolean;
        filter(callback: (item: Object, index: number, source: ObservableArray) => boolean): any[];
        find(callback: (item: Object, index: number, source: ObservableArray) => boolean): any;
        forEach(callback: (item: Object, index: number, source: ObservableArray) => void): void;
        indexOf(item: any): number;
        join(separator: string): string;
        map(callback: (item: Object, index: number, source: ObservableArray) => any): any[];
        parent(): ObservableObject;
        pop(): ObservableObject;
        push(...items: any[]): number;
        remove(item: Object): void;
        shift(): any;
        slice(begin: number, end?: number): any[];
        some(callback: (item: Object, index: number, source: ObservableArray) => boolean): boolean;
        splice(start: number): any[];
        splice(start: number, deleteCount: number, ...items: any[]): any[];
        toJSON(): any[];
        unshift(...items: any[]): number;
        wrap(object: Object, parent: Object): any;
        wrapAll(source: Object, target: Object): any;
    }

    class DataSource extends Observable {
        options: DataSourceOptions;

        static create(options?: DataSourceOptions): DataSource;

        constructor(options?: DataSourceOptions);
        init(options?: DataSourceOptions): void;
        add(model: Object): kendo.data.Model;
        add(model: kendo.data.Model): kendo.data.Model;
        aggregate(val: any): void;
        aggregate(): any;
        aggregates(): any;
        at(index: number): kendo.data.ObservableObject;
        cancelChanges(model?: kendo.data.Model): void;
        data(): kendo.data.ObservableArray;
        data(value: any): void;
        fetch(callback?: Function): JQueryPromise<any>;
        filter(filters: DataSourceFilterItem): void;
        filter(filters: DataSourceFilterItem[]): void;
        filter(filters: DataSourceFilters): void;
        filter(): DataSourceFilters;
        get(id: any): kendo.data.Model;
        getByUid(uid: string): kendo.data.Model;
        group(groups: any): void;
        group(): any;
        hasChanges(): boolean;
        indexOf(value: kendo.data.ObservableObject): number;
        insert(index: number, model: kendo.data.Model): kendo.data.Model;
        insert(index: number, model: Object): kendo.data.Model;
        online(value: boolean): void;
        online(): boolean;
        offlineData(data: any[]): void;
        offlineData(): any[];
        page(): number;
        page(page: number): void;
        pageSize(): number;
        pageSize(size: number): void;
        pushCreate(model: Object): void;
        pushCreate(models: any[]): void;
        pushDestroy(model: Object): void;
        pushDestroy(models: any[]): void;
        pushUpdate(model: Object): void;
        pushUpdate(models: any[]): void;
        query(options?: any): JQueryPromise<any>;
        read(data?: any): JQueryPromise<any>;
        remove(model: kendo.data.ObservableObject): void;
        skip(): number;
        sort(sort: DataSourceSortItem): void;
        sort(sort: DataSourceSortItem[]): void;
        sort(): DataSourceSortItem[];
        sync(): JQueryPromise<any>;
        total(): number;
        totalPages(): number;
        view(): kendo.data.ObservableArray;
    }

    interface DataSourceAggregateItem {
        field?: string;
        aggregate?: string;
    }

    interface DataSourceFilter {
    }

    interface DataSourceFilterItem extends DataSourceFilter {
        operator?: string | Function;
        field?: string;
        value?: any;
    }

    interface DataSourceFilters extends DataSourceFilter {
        logic?: string;
        filters?: DataSourceFilter[];
    }

    interface DataSourceGroupItemAggregate {
        field?: string;
        aggregate?: string;
    }

    interface DataSourceGroupItem {
        field?: string;
        dir?: string;
        aggregates?: DataSourceGroupItemAggregate[];
    }

    interface DataSourceSchema {
        aggregates?: any;
        data?: any;
        errors?: any;
        groups?: any;
        parse?: Function;
        total?: any;
        type?: string;
    }

    interface DataSourceSortItem {
        field?: string;
        dir?: string;
    }

    interface DataSourceTransportCreate extends JQueryAjaxSettings {
        cache?: boolean;
        contentType?: string;
        data?: any;
        dataType?: string;
        type?: string;
        url?: any;
    }

    interface DataSourceTransportDestroy extends JQueryAjaxSettings {
        cache?: boolean;
        contentType?: string;
        data?: any;
        dataType?: string;
        type?: string;
        url?: any;
    }

    interface DataSourceTransportRead extends JQueryAjaxSettings {
        cache?: boolean;
        contentType?: string;
        data?: any;
        dataType?: string;
        type?: string;
        url?: any;
    }

    interface DataSourceTransportUpdate extends JQueryAjaxSettings {
        cache?: boolean;
        contentType?: string;
        data?: any;
        dataType?: string;
        type?: string;
        url?: any;
    }

    interface DataSourceTransportOptions {
        success: (data?: any) => void;
        error: (error?: any) => void;
        data: any;
    }

    interface DataSourceOptions {
        aggregate?: DataSourceAggregateItem[];
        autoSync?: boolean;
        batch?: boolean;
        data?: any;
        filter?: any;
        group?: DataSourceGroupItem | DataSourceGroupItem[];
        inPlaceSort?: boolean;
        offlineStorage?: any;
        page?: number;
        pageSize?: number;
        schema?: DataSourceSchema;
        serverAggregates?: boolean;
        serverFiltering?: boolean;
        serverGrouping?: boolean;
        serverPaging?: boolean;
        serverSorting?: boolean;
        sort?: any;
        transport?: DataSourceTransport;
        type?: string;
        change?(e: DataSourceChangeEvent): void;
        error?(e: DataSourceErrorEvent): void;
        push?(e: DataSourcePushEvent): void;
        sync?(e: DataSourceEvent): void;
        requestStart?(e: DataSourceRequestStartEvent): void;
        requestEnd?(e: DataSourceRequestEndEvent): void;
    }

    interface DataSourceEvent {
        sender?: DataSource;
    }

    interface DataSourceItemOrGroup {
    }

    interface DataSourceGroup extends DataSourceItemOrGroup {
        aggregates: any[];
        field: string;
        hasSubgroups: boolean;
        items: DataSourceItemOrGroup[];
        value: any;
    }

    interface DataSourceChangeEvent extends DataSourceEvent {
        field?: string;
        value?: Model;
        action?: string;
        index?: number;
        items?: DataSourceItemOrGroup[];
        node?: any;
    }

    interface DataSourcePushEvent extends DataSourceEvent {
        items?: DataSourceItemOrGroup[];
        type?: string;

    }

    interface DataSourceErrorEvent extends DataSourceEvent {
        xhr: JQueryXHR;
        status: string;
        errorThrown: any;
        errors?: any;
    }

    interface DataSourceRequestStartEvent extends DataSourceEvent {
        type?: string;
        preventDefault(): void;
    }

    interface DataSourceRequestEndEvent extends DataSourceEvent {
        response?: any;
        type?: string;
    }
}

declare namespace kendo.ui {
    class Widget extends Observable {
        static fn: any;

        element: JQuery;
        options: any;
        events: string[];

        static extend(prototype: Object): Widget;

        constructor(element: Element, options?: Object);
        constructor(element: JQuery, options?: Object);
        constructor(selector: String, options?: Object);
        init(element: Element, options?: Object): void;
        init(element: JQuery, options?: Object): void;
        init(selector: String, options?: Object): void;
        destroy(): void;
        setOptions(options: Object): void;
        resize(force?: boolean): void;
    }
}

declare namespace kendo.dataviz {
    class ChartAxis extends Observable {


        options: ChartAxisOptions;




        range(): any;
        slot(from: string, to?: string, limit?: boolean): kendo.geometry.Rect;
        slot(from: string, to?: number, limit?: boolean): kendo.geometry.Rect;
        slot(from: string, to?: Date, limit?: boolean): kendo.geometry.Rect;
        slot(from: number, to?: string, limit?: boolean): kendo.geometry.Rect;
        slot(from: number, to?: number, limit?: boolean): kendo.geometry.Rect;
        slot(from: number, to?: Date, limit?: boolean): kendo.geometry.Rect;
        slot(from: Date, to?: string, limit?: boolean): kendo.geometry.Rect;
        slot(from: Date, to?: number, limit?: boolean): kendo.geometry.Rect;
        slot(from: Date, to?: Date, limit?: boolean): kendo.geometry.Rect;
        value(point: kendo.geometry.Point): void;
        valueRange(): void;

    }

    interface ChartAxisOptions {
        name?: string;
    }
    interface ChartAxisEvent {
        sender: ChartAxis;
        preventDefault: Function;
        isDefaultPrevented(): boolean;
    }


    class ChartPane extends Observable {


        options: ChartPaneOptions;

        chartsVisual: kendo.drawing.Group;
        visual: kendo.drawing.Group;



        findAxisByName(name: string): kendo.dataviz.ChartAxis;
        series(): any;

    }

    class ChartPlotArea extends Observable {


        options: ChartPlotAreaOptions;

        backgroundVisual: kendo.drawing.MultiPath;
        visual: kendo.drawing.Group;




    }

    interface ChartPlotAreaOptions {
        name?: string;
    }

    class ChartPoint extends Observable {


        options: ChartPointOptions;

        category: string | Date | number;
        dataItem: any;
        percentage: number;
        runningTotal: number;
        total: number;
        value: number;
        visual: kendo.drawing.Element;




    }

    interface ChartPointOptions {
        name?: string;
    }

    class ChartSeries extends Observable {


        options: ChartSeriesOptions;




        data(): any;
        data(data: any): void;
        findPoint(callback: Function): kendo.dataviz.ChartPoint;
        points(): any;
        points(filter: Function): void;
        toggleHighlight(show: boolean, filter: Function): void;
        toggleHighlight(show: boolean, filter: any): void;
        toggleVisibility(show: boolean, filter: Function): void;

    }

    interface ChartSeriesOptions {
        name?: string;
    }

    interface ChartPaneOptions {
        name?: string;
    }
}

declare namespace kendo.dataviz.ui {

    class Chart extends kendo.ui.Widget {

        static fn: Chart;

        options: ChartOptions;

        dataSource: kendo.data.DataSource;
        surface: kendo.drawing.Surface;

        element: JQuery;
        wrapper: JQuery;

        static extend(proto: Object): Chart;

        constructor(element: Element, options?: ChartOptions);


        destroy(): void;
        exportImage(options: any): JQueryPromise<any>;
        exportPDF(options?: kendo.drawing.PDFOptions): JQueryPromise<any>;
        exportSVG(options: any): JQueryPromise<any>;
        findAxisByName(name: string): kendo.dataviz.ChartAxis;
        findPaneByIndex(index: number): kendo.dataviz.ChartPane;
        findPaneByName(name: string): kendo.dataviz.ChartPane;
        findSeries(callback: Function): kendo.dataviz.ChartSeries;
        findSeriesByIndex(index: number): kendo.dataviz.ChartSeries;
        findSeriesByName(name: string): kendo.dataviz.ChartSeries;
        getAxis(name: string): kendo.dataviz.ChartAxis;
        hideTooltip(): void;
        plotArea(): kendo.dataviz.ChartPlotArea;
        redraw(): void;
        refresh(): void;
        resize(force?: boolean): void;
        saveAsPDF(): void;
        setDataSource(dataSource: kendo.data.DataSource): void;
        setOptions(options: any): void;
        showTooltip(filter: Function): void;
        showTooltip(filter: number): void;
        showTooltip(filter: Date): void;
        showTooltip(filter: string): void;
        svg(): string;
        imageDataURL(): string;
        toggleHighlight(show: boolean, options: any): void;

    }

    interface ChartAxisDefaultsCrosshairTooltipBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartAxisDefaultsCrosshairTooltipPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartAxisDefaultsCrosshairTooltip {
        background?: string;
        border?: ChartAxisDefaultsCrosshairTooltipBorder;
        color?: string;
        font?: string;
        format?: string;
        padding?: ChartAxisDefaultsCrosshairTooltipPadding;
        template?: string | Function;
        visible?: boolean;
    }

    interface ChartAxisDefaultsCrosshair {
        color?: string;
        dashType?: string;
        opacity?: number;
        tooltip?: ChartAxisDefaultsCrosshairTooltip;
        visible?: boolean;
        width?: number;
    }

    interface ChartAxisDefaultsLabelsMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartAxisDefaultsLabelsPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartAxisDefaultsLabelsRotation {
        align?: string;
        angle?: number | string;
    }

    interface ChartAxisDefaultsLabels {
        font?: string;
        format?: string;
        margin?: ChartAxisDefaultsLabelsMargin;
        mirror?: boolean;
        padding?: ChartAxisDefaultsLabelsPadding;
        rotation?: string | number | ChartAxisDefaultsLabelsRotation;
        skip?: number;
        step?: number;
        template?: string | Function;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartAxisDefaultsLine {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
    }

    interface ChartAxisDefaultsMajorGridLines {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartAxisDefaultsMajorTicks {
        color?: string;
        size?: number;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartAxisDefaultsTitleBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartAxisDefaultsTitleMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartAxisDefaultsTitlePadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartAxisDefaultsTitle {
        background?: string;
        border?: ChartAxisDefaultsTitleBorder;
        color?: string;
        font?: string;
        margin?: ChartAxisDefaultsTitleMargin;
        padding?: ChartAxisDefaultsTitlePadding;
        position?: string;
        rotation?: number;
        text?: string;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartAxisDefaultsMinorGridLines {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartAxisDefaultsMinorTicks {
        color?: string;
        size?: number;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartAxisDefaultsPlotBand {
        color?: string;
        from?: number;
        opacity?: number;
        to?: number;
    }

    interface ChartAxisDefaults {
        background?: string;
        color?: string;
        crosshair?: ChartAxisDefaultsCrosshair;
        labels?: ChartAxisDefaultsLabels;
        line?: ChartAxisDefaultsLine;
        majorGridLines?: ChartAxisDefaultsMajorGridLines;
        majorTicks?: ChartAxisDefaultsMajorTicks;
        minorGridLines?: ChartAxisDefaultsMinorGridLines;
        minorTicks?: ChartAxisDefaultsMinorTicks;
        narrowRange?: boolean;
        pane?: string;
        plotBands?: ChartAxisDefaultsPlotBand[];
        reverse?: boolean;
        startAngle?: number;
        title?: ChartAxisDefaultsTitle;
        visible?: boolean;
    }

    interface ChartCategoryAxisItemAutoBaseUnitSteps {
        milliseconds?: any;
        seconds?: any;
        minutes?: any;
        hours?: any;
        days?: any;
        weeks?: any;
        months?: any;
        years?: any;
    }

    interface ChartCategoryAxisItemCrosshairTooltipBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartCategoryAxisItemCrosshairTooltipPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartCategoryAxisItemCrosshairTooltip {
        background?: string;
        border?: ChartCategoryAxisItemCrosshairTooltipBorder;
        color?: string;
        font?: string;
        format?: string;
        padding?: ChartCategoryAxisItemCrosshairTooltipPadding;
        template?: string | Function;
        visible?: boolean;
    }

    interface ChartCategoryAxisItemCrosshair {
        color?: string;
        dashType?: string;
        opacity?: number;
        tooltip?: ChartCategoryAxisItemCrosshairTooltip;
        visible?: boolean;
        width?: number;
    }

    interface ChartCategoryAxisItemLabelsBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartCategoryAxisItemLabelsDateFormats {
        days?: string;
        hours?: string;
        months?: string;
        weeks?: string;
        years?: string;
    }

    interface ChartCategoryAxisItemLabelsMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartCategoryAxisItemLabelsPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartCategoryAxisItemLabelsRotation {
        align?: string;
        angle?: number | string;
    }

    interface ChartCategoryAxisItemLabels {
        background?: string;
        border?: ChartCategoryAxisItemLabelsBorder;
        color?: string;
        culture?: string;
        dateFormats?: ChartCategoryAxisItemLabelsDateFormats;
        font?: string;
        format?: string;
        margin?: ChartCategoryAxisItemLabelsMargin;
        mirror?: boolean;
        padding?: ChartCategoryAxisItemLabelsPadding;
        rotation?: string | number | ChartCategoryAxisItemLabelsRotation;
        skip?: number;
        step?: number;
        template?: string | Function;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartCategoryAxisItemLine {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
    }

    interface ChartCategoryAxisItemMajorGridLines {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartCategoryAxisItemMajorTicks {
        color?: string;
        size?: number;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartCategoryAxisItemMinorGridLines {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartCategoryAxisItemMinorTicks {
        color?: string;
        size?: number;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartCategoryAxisItemNotesDataItemIconBorder {
        color?: string;
        width?: number;
    }

    interface ChartCategoryAxisItemNotesDataItemIcon {
        background?: string;
        border?: ChartCategoryAxisItemNotesDataItemIconBorder;
        size?: number;
        type?: string;
        visible?: boolean;
    }

    interface ChartCategoryAxisItemNotesDataItemLabelBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartCategoryAxisItemNotesDataItemLabel {
        background?: string;
        border?: ChartCategoryAxisItemNotesDataItemLabelBorder;
        color?: string;
        font?: string;
        template?: string | Function;
        visible?: boolean;
        rotation?: number;
        format?: string;
        text?: string;
        position?: string;
    }

    interface ChartCategoryAxisItemNotesDataItemLine {
        width?: number;
        color?: string;
        length?: number;
    }

    interface ChartCategoryAxisItemNotesDataItem {
        value?: any;
        position?: string;
        icon?: ChartCategoryAxisItemNotesDataItemIcon;
        label?: ChartCategoryAxisItemNotesDataItemLabel;
        line?: ChartCategoryAxisItemNotesDataItemLine;
    }

    interface ChartCategoryAxisItemNotesIconBorder {
        color?: string;
        width?: number;
    }

    interface ChartCategoryAxisItemNotesIcon {
        background?: string;
        border?: ChartCategoryAxisItemNotesIconBorder;
        size?: number;
        type?: string;
        visible?: boolean;
    }

    interface ChartCategoryAxisItemNotesLabelBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartCategoryAxisItemNotesLabel {
        background?: string;
        border?: ChartCategoryAxisItemNotesLabelBorder;
        color?: string;
        font?: string;
        template?: string | Function;
        visible?: boolean;
        rotation?: number;
        format?: string;
        position?: string;
    }

    interface ChartCategoryAxisItemNotesLine {
        dashType?: string;
        width?: number;
        color?: string;
        length?: number;
    }

    interface ChartCategoryAxisItemNotes {
        position?: string;
        icon?: ChartCategoryAxisItemNotesIcon;
        label?: ChartCategoryAxisItemNotesLabel;
        line?: ChartCategoryAxisItemNotesLine;
        data?: ChartCategoryAxisItemNotesDataItem[];
        visual?: Function;
    }

    interface ChartCategoryAxisItemPlotBand {
        color?: string;
        from?: number;
        opacity?: number;
        to?: number;
    }

    interface ChartCategoryAxisItemSelectMousewheel {
        reverse?: boolean;
        zoom?: string;
    }

    interface ChartCategoryAxisItemSelect {
        from?: any;
        max?: any;
        min?: any;
        mousewheel?: ChartCategoryAxisItemSelectMousewheel;
        to?: any;
    }

    interface ChartCategoryAxisItemTitleBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartCategoryAxisItemTitleMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartCategoryAxisItemTitlePadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartCategoryAxisItemTitle {
        background?: string;
        border?: ChartCategoryAxisItemTitleBorder;
        color?: string;
        font?: string;
        margin?: ChartCategoryAxisItemTitleMargin;
        padding?: ChartCategoryAxisItemTitlePadding;
        position?: string;
        rotation?: number;
        text?: string;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartCategoryAxisItem {
        autoBaseUnitSteps?: ChartCategoryAxisItemAutoBaseUnitSteps;
        axisCrossingValue?: any | Date | any;
        background?: string;
        baseUnit?: string;
        baseUnitStep?: any;
        categories?: any;
        color?: string;
        crosshair?: ChartCategoryAxisItemCrosshair;
        field?: string;
        justified?: boolean;
        labels?: ChartCategoryAxisItemLabels;
        line?: ChartCategoryAxisItemLine;
        majorGridLines?: ChartCategoryAxisItemMajorGridLines;
        majorTicks?: ChartCategoryAxisItemMajorTicks;
        max?: any;
        maxDateGroups?: number;
        maxDivisions?: number;
        min?: any;
        minorGridLines?: ChartCategoryAxisItemMinorGridLines;
        minorTicks?: ChartCategoryAxisItemMinorTicks;
        name?: string;
        pane?: string;
        plotBands?: ChartCategoryAxisItemPlotBand[];
        reverse?: boolean;
        roundToBaseUnit?: boolean;
        select?: ChartCategoryAxisItemSelect;
        startAngle?: number;
        title?: ChartCategoryAxisItemTitle;
        type?: string;
        visible?: boolean;
        weekStartDay?: number;
        notes?: ChartCategoryAxisItemNotes;
    }

    interface ChartChartAreaBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartChartAreaMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartChartArea {
        background?: string;
        border?: ChartChartAreaBorder;
        height?: number;
        margin?: ChartChartAreaMargin;
        opacity?: number;
        width?: number;
    }

    interface ChartLegendBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartLegendInactiveItemsLabels {
        color?: string;
        font?: string;
        template?: string | Function;
    }

    interface ChartLegendInactiveItems {
        labels?: ChartLegendInactiveItemsLabels;
    }

    interface ChartLegendItem {
        cursor?: string;
        visual?: Function;
    }

    interface ChartLegendLabelsMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartLegendLabelsPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartLegendLabels {
        color?: string;
        font?: string;
        margin?: ChartLegendLabelsMargin;
        padding?: ChartLegendLabelsPadding;
        template?: string | Function;
    }

    interface ChartLegendMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartLegendPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartLegend {
        align?: string;
        background?: string;
        border?: ChartLegendBorder;
        height?: number;
        inactiveItems?: ChartLegendInactiveItems;
        item?: ChartLegendItem;
        labels?: ChartLegendLabels;
        margin?: ChartLegendMargin;
        offsetX?: number;
        offsetY?: number;
        orientation?: string;
        padding?: ChartLegendPadding;
        position?: string;
        reverse?: boolean;
        spacing?: number;
        visible?: boolean;
        width?: number;
    }

    interface ChartPaneBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartPaneMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartPanePadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartPaneTitleBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartPaneTitleMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartPaneTitle {
        background?: string;
        border?: ChartPaneTitleBorder;
        color?: string;
        font?: string;
        margin?: ChartPaneTitleMargin;
        position?: string;
        text?: string;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartPane {
        background?: string;
        border?: ChartPaneBorder;
        clip?: boolean;
        height?: number;
        margin?: ChartPaneMargin;
        name?: string;
        padding?: ChartPanePadding;
        title?: string | ChartPaneTitle;
    }

    interface ChartPannable {
        key?: string;
        lock?: string;
    }

    interface ChartPdfMargin {
        bottom?: number | string;
        left?: number | string;
        right?: number | string;
        top?: number | string;
    }

    interface ChartPdf {
        author?: string;
        creator?: string;
        date?: Date;
        forceProxy?: boolean;
        fileName?: string;
        keywords?: string;
        landscape?: boolean;
        margin?: ChartPdfMargin;
        paperSize?: string | any;
        proxyURL?: string;
        proxyTarget?: string;
        subject?: string;
        title?: string;
    }

    interface ChartPlotAreaBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartPlotAreaMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartPlotAreaPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartPlotArea {
        background?: string;
        border?: ChartPlotAreaBorder;
        margin?: ChartPlotAreaMargin;
        opacity?: number;
        padding?: ChartPlotAreaPadding;
    }

    interface ChartSeriesItemBorder {
        color?: string | Function;
        dashType?: string | Function;
        opacity?: number | Function;
        width?: number | Function;
    }

    interface ChartSeriesItemConnectors {
        color?: string | Function;
        padding?: number;
        width?: number;
    }

    interface ChartSeriesItemErrorBarsLine {
        width?: number;
        dashType?: string;
    }

    interface ChartSeriesItemErrorBars {
        value?: string | number | any | Function;
        visual?: Function;
        xValue?: string | number | any | Function;
        yValue?: string | number | any | Function;
        endCaps?: boolean;
        color?: string;
        line?: ChartSeriesItemErrorBarsLine;
    }

    interface ChartSeriesItemExtremesBorder {
        color?: string | Function;
        width?: number | Function;
    }

    interface ChartSeriesItemExtremes {
        background?: string | Function;
        border?: Function | ChartSeriesItemExtremesBorder;
        size?: number | Function;
        type?: string | Function;
        rotation?: number | Function;
    }

    interface ChartSeriesItemHighlightBorder {
        color?: string;
        opacity?: number;
        width?: number;
    }

    interface ChartSeriesItemHighlightLine {
        dashType?: string;
        color?: string;
        opacity?: number;
        width?: number;
    }

    interface ChartSeriesItemHighlight {
        border?: ChartSeriesItemHighlightBorder;
        color?: string;
        line?: ChartSeriesItemHighlightLine;
        opacity?: number;
        toggle?: Function;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartSeriesItemLabelsBorder {
        color?: string | Function;
        dashType?: string | Function;
        width?: number | Function;
    }

    interface ChartSeriesItemLabelsFromBorder {
        color?: string | Function;
        dashType?: string | Function;
        width?: number | Function;
    }

    interface ChartSeriesItemLabelsFromMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesItemLabelsFromPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesItemLabelsFrom {
        background?: string | Function;
        border?: ChartSeriesItemLabelsFromBorder;
        color?: string | Function;
        font?: string | Function;
        format?: string | Function;
        margin?: ChartSeriesItemLabelsFromMargin;
        padding?: ChartSeriesItemLabelsFromPadding;
        position?: string | Function;
        template?: string | Function;
        visible?: boolean | Function;
    }

    interface ChartSeriesItemLabelsMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesItemLabelsPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesItemLabelsToBorder {
        color?: string | Function;
        dashType?: string | Function;
        width?: number | Function;
    }

    interface ChartSeriesItemLabelsToMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesItemLabelsToPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesItemLabelsTo {
        background?: string | Function;
        border?: ChartSeriesItemLabelsToBorder;
        color?: string | Function;
        font?: string | Function;
        format?: string | Function;
        margin?: ChartSeriesItemLabelsToMargin;
        padding?: ChartSeriesItemLabelsToPadding;
        position?: string | Function;
        template?: string | Function;
        visible?: boolean | Function;
    }

    interface ChartSeriesItemLabels {
        align?: string;
        background?: string | Function;
        border?: ChartSeriesItemLabelsBorder;
        color?: string | Function;
        distance?: number;
        font?: string | Function;
        format?: string | Function;
        margin?: ChartSeriesItemLabelsMargin;
        padding?: ChartSeriesItemLabelsPadding;
        position?: string | Function;
        rotation?: string | number;
        template?: string | Function;
        visible?: boolean | Function;
        visual?: Function;
        from?: ChartSeriesItemLabelsFrom;
        to?: ChartSeriesItemLabelsTo;
    }

    interface ChartSeriesItemLine {
        color?: string;
        opacity?: number;
        width?: number;
        style?: string;
    }

    interface ChartSeriesItemMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesItemMarkersBorder {
        color?: string | Function;
        width?: number | Function;
    }

    interface ChartSeriesItemMarkersFromBorder {
        color?: string | Function;
        width?: number | Function;
    }

    interface ChartSeriesItemMarkersFrom {
        background?: string | Function;
        border?: Function | ChartSeriesItemMarkersFromBorder;
        size?: number | Function;
        type?: string | Function;
        visible?: boolean | Function;
        visual?: Function;
        rotation?: number | Function;
    }

    interface ChartSeriesItemMarkersToBorder {
        color?: string | Function;
        width?: number | Function;
    }

    interface ChartSeriesItemMarkersTo {
        background?: string | Function;
        border?: Function | ChartSeriesItemMarkersToBorder;
        size?: number | Function;
        type?: string | Function;
        visible?: boolean | Function;
        visual?: Function;
        rotation?: number | Function;
    }

    interface ChartSeriesItemMarkers {
        background?: string | Function;
        border?: Function | ChartSeriesItemMarkersBorder;
        from?: ChartSeriesItemMarkersFrom;
        size?: number | Function;
        to?: ChartSeriesItemMarkersTo;
        type?: string | Function;
        visible?: boolean | Function;
        visual?: Function;
        rotation?: number | Function;
    }

    interface ChartSeriesItemNegativeValues {
        color?: string;
        visible?: boolean;
    }

    interface ChartSeriesItemNotesIconBorder {
        color?: string;
        width?: number;
    }

    interface ChartSeriesItemNotesIcon {
        background?: string;
        border?: ChartSeriesItemNotesIconBorder;
        size?: number;
        type?: string;
        visible?: boolean;
    }

    interface ChartSeriesItemNotesLabelBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartSeriesItemNotesLabel {
        background?: string;
        border?: ChartSeriesItemNotesLabelBorder;
        color?: string;
        font?: string;
        template?: string | Function;
        visible?: boolean;
        rotation?: number;
        format?: string;
        position?: string;
    }

    interface ChartSeriesItemNotesLine {
        dashType?: string;
        width?: number;
        color?: string;
        length?: number;
    }

    interface ChartSeriesItemNotes {
        position?: string;
        icon?: ChartSeriesItemNotesIcon;
        label?: ChartSeriesItemNotesLabel;
        line?: ChartSeriesItemNotesLine;
        visual?: Function;
    }

    interface ChartSeriesItemOutliersBorder {
        color?: string | Function;
        width?: number | Function;
    }

    interface ChartSeriesItemOutliers {
        background?: string | Function;
        border?: Function | ChartSeriesItemOutliersBorder;
        size?: number | Function;
        type?: string | Function;
        rotation?: number | Function;
    }

    interface ChartSeriesItemOverlay {
        gradient?: string;
    }

    interface ChartSeriesItemStack {
        type?: string;
        group?: string;
    }

    interface ChartSeriesItemTargetBorder {
        color?: string | Function;
        dashType?: string | Function;
        width?: number | Function;
    }

    interface ChartSeriesItemTargetLine {
        width?: number | Function;
    }

    interface ChartSeriesItemTarget {
        border?: Function | ChartSeriesItemTargetBorder;
        color?: string | Function;
        line?: ChartSeriesItemTargetLine;
    }

    interface ChartSeriesItemTooltipBorder {
        color?: string;
        width?: number;
    }

    interface ChartSeriesItemTooltipPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesItemTooltip {
        background?: string;
        border?: ChartSeriesItemTooltipBorder;
        color?: string;
        font?: string;
        format?: string;
        padding?: ChartSeriesItemTooltipPadding;
        template?: string | Function;
        visible?: boolean;
    }

    interface ChartSeriesItem {
        aggregate?: string | Function;
        axis?: string;
        border?: ChartSeriesItemBorder;
        categoryAxis?: string;
        categoryField?: string;
        closeField?: string;
        color?: string | Function;
        colorField?: string;
        connectors?: ChartSeriesItemConnectors;
        currentField?: string;
        dashType?: string;
        data?: any;
        downColor?: string | Function;
        downColorField?: string;
        segmentSpacing?: number;
        summaryField?: string;
        neckRatio?: number;
        dynamicSlope?: boolean;
        dynamicHeight?: boolean;
        errorBars?: ChartSeriesItemErrorBars;
        errorLowField?: string;
        errorHighField?: string;
        xErrorLowField?: string;
        xErrorHighField?: string;
        yErrorLowField?: string;
        yErrorHighField?: string;
        explodeField?: string;
        field?: string;
        fromField?: string;
        toField?: string;
        noteTextField?: string;
        lowerField?: string;
        q1Field?: string;
        medianField?: string;
        q3Field?: string;
        upperField?: string;
        meanField?: string;
        outliersField?: string;
        gap?: number;
        highField?: string;
        highlight?: ChartSeriesItemHighlight;
        holeSize?: number;
        labels?: ChartSeriesItemLabels;
        line?: string | ChartSeriesItemLine;
        lowField?: string;
        margin?: ChartSeriesItemMargin;
        markers?: ChartSeriesItemMarkers;
        outliers?: ChartSeriesItemOutliers;
        extremes?: ChartSeriesItemExtremes;
        maxSize?: number;
        minSize?: number;
        missingValues?: string;
        style?: string;
        name?: string;
        negativeColor?: string;
        negativeValues?: ChartSeriesItemNegativeValues;
        opacity?: number;
        openField?: string;
        overlay?: ChartSeriesItemOverlay;
        padding?: number;
        size?: number;
        sizeField?: string;
        spacing?: number;
        stack?: boolean | string | ChartSeriesItemStack;
        startAngle?: number;
        target?: ChartSeriesItemTarget;
        targetField?: string;
        tooltip?: ChartSeriesItemTooltip;
        type?: string;
        visible?: boolean;
        visibleInLegend?: boolean;
        visibleInLegendField?: string;
        visual?: Function;
        width?: number;
        xAxis?: string;
        xField?: string;
        yAxis?: string;
        yField?: string;
        notes?: ChartSeriesItemNotes;
        zIndex?: number;
    }

    interface ChartSeriesDefaultsBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartSeriesDefaultsLabelsBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartSeriesDefaultsLabelsFromBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartSeriesDefaultsLabelsFromMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesDefaultsLabelsFromPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesDefaultsLabelsFrom {
        background?: string;
        border?: ChartSeriesDefaultsLabelsFromBorder;
        color?: string;
        font?: string;
        format?: string;
        margin?: ChartSeriesDefaultsLabelsFromMargin;
        padding?: ChartSeriesDefaultsLabelsFromPadding;
        template?: string | Function;
        visible?: boolean;
    }

    interface ChartSeriesDefaultsLabelsMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesDefaultsLabelsPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesDefaultsLabelsToBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartSeriesDefaultsLabelsToMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesDefaultsLabelsToPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesDefaultsLabelsTo {
        background?: string;
        border?: ChartSeriesDefaultsLabelsToBorder;
        color?: string;
        font?: string;
        format?: string;
        margin?: ChartSeriesDefaultsLabelsToMargin;
        padding?: ChartSeriesDefaultsLabelsToPadding;
        template?: string | Function;
        visible?: boolean;
    }

    interface ChartSeriesDefaultsLabels {
        background?: string;
        border?: ChartSeriesDefaultsLabelsBorder;
        color?: string;
        font?: string;
        format?: string;
        margin?: ChartSeriesDefaultsLabelsMargin;
        padding?: ChartSeriesDefaultsLabelsPadding;
        rotation?: string | number;
        template?: string | Function;
        visible?: boolean;
        visual?: Function;
        from?: ChartSeriesDefaultsLabelsFrom;
        to?: ChartSeriesDefaultsLabelsTo;
    }

    interface ChartSeriesDefaultsNotesIconBorder {
        color?: string;
        width?: number;
    }

    interface ChartSeriesDefaultsNotesIcon {
        background?: string;
        border?: ChartSeriesDefaultsNotesIconBorder;
        size?: number;
        type?: string;
        visible?: boolean;
    }

    interface ChartSeriesDefaultsNotesLabelBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartSeriesDefaultsNotesLabel {
        background?: string;
        border?: ChartSeriesDefaultsNotesLabelBorder;
        color?: string;
        font?: string;
        template?: string | Function;
        visible?: boolean;
        rotation?: number;
        format?: string;
        position?: string;
    }

    interface ChartSeriesDefaultsNotesLine {
        dashType?: string;
        width?: number;
        color?: string;
        length?: number;
    }

    interface ChartSeriesDefaultsNotes {
        icon?: ChartSeriesDefaultsNotesIcon;
        label?: ChartSeriesDefaultsNotesLabel;
        line?: ChartSeriesDefaultsNotesLine;
        visual?: Function;
    }

    interface ChartSeriesDefaultsOverlay {
        gradient?: string;
    }

    interface ChartSeriesDefaultsStack {
        type?: string;
    }

    interface ChartSeriesDefaultsTooltipBorder {
        color?: string;
        width?: number;
    }

    interface ChartSeriesDefaultsTooltipPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartSeriesDefaultsTooltip {
        background?: string;
        border?: ChartSeriesDefaultsTooltipBorder;
        color?: string;
        font?: string;
        format?: string;
        padding?: ChartSeriesDefaultsTooltipPadding;
        template?: string | Function;
        visible?: boolean;
    }

    interface ChartSeriesDefaults {
        area?: any;
        bar?: any;
        border?: ChartSeriesDefaultsBorder;
        bubble?: any;
        candlestick?: any;
        column?: any;
        donut?: any;
        gap?: number;
        labels?: ChartSeriesDefaultsLabels;
        line?: any;
        ohlc?: any;
        overlay?: ChartSeriesDefaultsOverlay;
        pie?: any;
        rangeArea?: any;
        scatter?: any;
        scatterLine?: any;
        spacing?: number;
        stack?: boolean | ChartSeriesDefaultsStack;
        type?: string;
        tooltip?: ChartSeriesDefaultsTooltip;
        verticalArea?: any;
        verticalLine?: any;
        verticalRangeArea?: any;
        visual?: Function;
        notes?: ChartSeriesDefaultsNotes;
    }

    interface ChartTitleBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartTitleMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartTitlePadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartTitle {
        align?: string;
        background?: string;
        border?: ChartTitleBorder;
        color?: string;
        font?: string;
        margin?: ChartTitleMargin;
        padding?: ChartTitlePadding;
        position?: string;
        text?: string;
        visible?: boolean;
    }

    interface ChartTooltipBorder {
        color?: string;
        width?: number;
    }

    interface ChartTooltipPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartTooltip {
        background?: string;
        border?: ChartTooltipBorder;
        color?: string;
        font?: string;
        format?: string;
        opacity?: number;
        padding?: ChartTooltipPadding;
        shared?: boolean;
        sharedTemplate?: string | Function;
        template?: string | Function;
        visible?: boolean;
    }

    interface ChartValueAxisItemCrosshairTooltipBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartValueAxisItemCrosshairTooltipPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartValueAxisItemCrosshairTooltip {
        background?: string;
        border?: ChartValueAxisItemCrosshairTooltipBorder;
        color?: string;
        font?: string;
        format?: string;
        padding?: ChartValueAxisItemCrosshairTooltipPadding;
        template?: string | Function;
        visible?: boolean;
    }

    interface ChartValueAxisItemCrosshair {
        color?: string;
        dashType?: string;
        opacity?: number;
        tooltip?: ChartValueAxisItemCrosshairTooltip;
        visible?: boolean;
        width?: number;
    }

    interface ChartValueAxisItemLabelsBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartValueAxisItemLabelsMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartValueAxisItemLabelsPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartValueAxisItemLabelsRotation {
        align?: string;
        angle?: number | string;
    }

    interface ChartValueAxisItemLabels {
        background?: string;
        border?: ChartValueAxisItemLabelsBorder;
        color?: string;
        font?: string;
        format?: string;
        margin?: ChartValueAxisItemLabelsMargin;
        mirror?: boolean;
        padding?: ChartValueAxisItemLabelsPadding;
        rotation?: string | number | ChartValueAxisItemLabelsRotation;
        skip?: number;
        step?: number;
        template?: string | Function;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartValueAxisItemLine {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
    }

    interface ChartValueAxisItemMajorGridLines {
        color?: string;
        dashType?: string;
        type?: string;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartValueAxisItemMajorTicks {
        color?: string;
        size?: number;
        visible?: boolean;
        step?: number;
        skip?: number;
    }

    interface ChartValueAxisItemMinorGridLines {
        color?: string;
        dashType?: string;
        type?: string;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartValueAxisItemMinorTicks {
        color?: string;
        size?: number;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartValueAxisItemNotesDataItemIconBorder {
        color?: string;
        width?: number;
    }

    interface ChartValueAxisItemNotesDataItemIcon {
        background?: string;
        border?: ChartValueAxisItemNotesDataItemIconBorder;
        size?: number;
        type?: string;
        visible?: boolean;
    }

    interface ChartValueAxisItemNotesDataItemLabelBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartValueAxisItemNotesDataItemLabel {
        background?: string;
        border?: ChartValueAxisItemNotesDataItemLabelBorder;
        color?: string;
        font?: string;
        template?: string | Function;
        visible?: boolean;
        rotation?: number;
        format?: string;
        text?: string;
        position?: string;
    }

    interface ChartValueAxisItemNotesDataItemLine {
        width?: number;
        color?: string;
        length?: number;
    }

    interface ChartValueAxisItemNotesDataItem {
        value?: any;
        position?: string;
        icon?: ChartValueAxisItemNotesDataItemIcon;
        label?: ChartValueAxisItemNotesDataItemLabel;
        line?: ChartValueAxisItemNotesDataItemLine;
    }

    interface ChartValueAxisItemNotesIconBorder {
        color?: string;
        width?: number;
    }

    interface ChartValueAxisItemNotesIcon {
        background?: string;
        border?: ChartValueAxisItemNotesIconBorder;
        size?: number;
        type?: string;
        visible?: boolean;
    }

    interface ChartValueAxisItemNotesLabelBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartValueAxisItemNotesLabel {
        background?: string;
        border?: ChartValueAxisItemNotesLabelBorder;
        color?: string;
        font?: string;
        template?: string | Function;
        visible?: boolean;
        rotation?: number;
        format?: string;
        position?: string;
    }

    interface ChartValueAxisItemNotesLine {
        dashType?: string;
        width?: number;
        color?: string;
        length?: number;
    }

    interface ChartValueAxisItemNotes {
        position?: string;
        icon?: ChartValueAxisItemNotesIcon;
        label?: ChartValueAxisItemNotesLabel;
        line?: ChartValueAxisItemNotesLine;
        data?: ChartValueAxisItemNotesDataItem[];
        visual?: Function;
    }

    interface ChartValueAxisItemPlotBand {
        color?: string;
        from?: number;
        opacity?: number;
        to?: number;
    }

    interface ChartValueAxisItemTitleBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartValueAxisItemTitleMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartValueAxisItemTitlePadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartValueAxisItemTitle {
        background?: string;
        border?: ChartValueAxisItemTitleBorder;
        color?: string;
        font?: string;
        margin?: ChartValueAxisItemTitleMargin;
        padding?: ChartValueAxisItemTitlePadding;
        position?: string;
        rotation?: number;
        text?: string;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartValueAxisItem {
        axisCrossingValue?: any | Date | any;
        background?: string;
        color?: string;
        crosshair?: ChartValueAxisItemCrosshair;
        labels?: ChartValueAxisItemLabels;
        line?: ChartValueAxisItemLine;
        majorGridLines?: ChartValueAxisItemMajorGridLines;
        majorUnit?: number;
        max?: number;
        min?: number;
        minorGridLines?: ChartValueAxisItemMinorGridLines;
        majorTicks?: ChartValueAxisItemMajorTicks;
        minorTicks?: ChartValueAxisItemMinorTicks;
        minorUnit?: number;
        name?: string;
        narrowRange?: boolean;
        pane?: string;
        plotBands?: ChartValueAxisItemPlotBand[];
        reverse?: boolean;
        title?: ChartValueAxisItemTitle;
        type?: string;
        visible?: boolean;
        notes?: ChartValueAxisItemNotes;
    }

    interface ChartXAxisItemCrosshairTooltipBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartXAxisItemCrosshairTooltipPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartXAxisItemCrosshairTooltip {
        background?: string;
        border?: ChartXAxisItemCrosshairTooltipBorder;
        color?: string;
        font?: string;
        format?: string;
        padding?: ChartXAxisItemCrosshairTooltipPadding;
        template?: string | Function;
        visible?: boolean;
    }

    interface ChartXAxisItemCrosshair {
        color?: string;
        dashType?: string;
        opacity?: number;
        tooltip?: ChartXAxisItemCrosshairTooltip;
        visible?: boolean;
        width?: number;
    }

    interface ChartXAxisItemLabelsBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartXAxisItemLabelsDateFormats {
        days?: string;
        hours?: string;
        months?: string;
        weeks?: string;
        years?: string;
    }

    interface ChartXAxisItemLabelsMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartXAxisItemLabelsPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartXAxisItemLabelsRotation {
        align?: string;
        angle?: number | string;
    }

    interface ChartXAxisItemLabels {
        background?: string;
        border?: ChartXAxisItemLabelsBorder;
        color?: string;
        culture?: string;
        dateFormats?: ChartXAxisItemLabelsDateFormats;
        font?: string;
        format?: string;
        margin?: ChartXAxisItemLabelsMargin;
        mirror?: boolean;
        padding?: ChartXAxisItemLabelsPadding;
        rotation?: string | number | ChartXAxisItemLabelsRotation;
        skip?: number;
        step?: number;
        template?: string | Function;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartXAxisItemLine {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
    }

    interface ChartXAxisItemMajorGridLines {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartXAxisItemMajorTicks {
        color?: string;
        size?: number;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartXAxisItemMinorGridLines {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartXAxisItemMinorTicks {
        color?: string;
        size?: number;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartXAxisItemNotesDataItemIconBorder {
        color?: string;
        width?: number;
    }

    interface ChartXAxisItemNotesDataItemIcon {
        background?: string;
        border?: ChartXAxisItemNotesDataItemIconBorder;
        size?: number;
        type?: string;
        visible?: boolean;
    }

    interface ChartXAxisItemNotesDataItemLabelBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartXAxisItemNotesDataItemLabel {
        background?: string;
        border?: ChartXAxisItemNotesDataItemLabelBorder;
        color?: string;
        font?: string;
        template?: string | Function;
        visible?: boolean;
        rotation?: number;
        format?: string;
        text?: string;
        position?: string;
    }

    interface ChartXAxisItemNotesDataItemLine {
        width?: number;
        color?: string;
        length?: number;
    }

    interface ChartXAxisItemNotesDataItem {
        value?: any;
        position?: string;
        icon?: ChartXAxisItemNotesDataItemIcon;
        label?: ChartXAxisItemNotesDataItemLabel;
        line?: ChartXAxisItemNotesDataItemLine;
    }

    interface ChartXAxisItemNotesIconBorder {
        color?: string;
        width?: number;
    }

    interface ChartXAxisItemNotesIcon {
        background?: string;
        border?: ChartXAxisItemNotesIconBorder;
        size?: number;
        type?: string;
        visible?: boolean;
    }

    interface ChartXAxisItemNotesLabelBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartXAxisItemNotesLabel {
        background?: string;
        border?: ChartXAxisItemNotesLabelBorder;
        color?: string;
        font?: string;
        template?: string | Function;
        visible?: boolean;
        rotation?: number;
        format?: string;
        position?: string;
    }

    interface ChartXAxisItemNotesLine {
        dashType?: string;
        width?: number;
        color?: string;
        length?: number;
    }

    interface ChartXAxisItemNotes {
        position?: string;
        icon?: ChartXAxisItemNotesIcon;
        label?: ChartXAxisItemNotesLabel;
        line?: ChartXAxisItemNotesLine;
        data?: ChartXAxisItemNotesDataItem[];
        visual?: Function;
    }

    interface ChartXAxisItemPlotBand {
        color?: string;
        from?: number;
        opacity?: number;
        to?: number;
    }

    interface ChartXAxisItemTitleBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartXAxisItemTitleMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartXAxisItemTitlePadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartXAxisItemTitle {
        background?: string;
        border?: ChartXAxisItemTitleBorder;
        color?: string;
        font?: string;
        margin?: ChartXAxisItemTitleMargin;
        padding?: ChartXAxisItemTitlePadding;
        position?: string;
        rotation?: number;
        text?: string;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartXAxisItem {
        axisCrossingValue?: any | Date | any;
        background?: string;
        baseUnit?: string;
        color?: string;
        crosshair?: ChartXAxisItemCrosshair;
        labels?: ChartXAxisItemLabels;
        line?: ChartXAxisItemLine;
        majorGridLines?: ChartXAxisItemMajorGridLines;
        minorGridLines?: ChartXAxisItemMinorGridLines;
        minorTicks?: ChartXAxisItemMinorTicks;
        majorTicks?: ChartXAxisItemMajorTicks;
        majorUnit?: number;
        max?: any;
        min?: any;
        minorUnit?: number;
        name?: string;
        narrowRange?: boolean;
        pane?: string;
        plotBands?: ChartXAxisItemPlotBand[];
        reverse?: boolean;
        startAngle?: number;
        title?: ChartXAxisItemTitle;
        type?: string;
        visible?: boolean;
        notes?: ChartXAxisItemNotes;
    }

    interface ChartYAxisItemCrosshairTooltipBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartYAxisItemCrosshairTooltipPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartYAxisItemCrosshairTooltip {
        background?: string;
        border?: ChartYAxisItemCrosshairTooltipBorder;
        color?: string;
        font?: string;
        format?: string;
        padding?: ChartYAxisItemCrosshairTooltipPadding;
        template?: string | Function;
        visible?: boolean;
    }

    interface ChartYAxisItemCrosshair {
        color?: string;
        dashType?: string;
        opacity?: number;
        tooltip?: ChartYAxisItemCrosshairTooltip;
        visible?: boolean;
        width?: number;
    }

    interface ChartYAxisItemLabelsBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartYAxisItemLabelsDateFormats {
        days?: string;
        hours?: string;
        months?: string;
        weeks?: string;
        years?: string;
    }

    interface ChartYAxisItemLabelsMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartYAxisItemLabelsPadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartYAxisItemLabelsRotation {
        align?: string;
        angle?: number;
    }

    interface ChartYAxisItemLabels {
        background?: string;
        border?: ChartYAxisItemLabelsBorder;
        color?: string;
        culture?: string;
        dateFormats?: ChartYAxisItemLabelsDateFormats;
        font?: string;
        format?: string;
        margin?: ChartYAxisItemLabelsMargin;
        mirror?: boolean;
        padding?: ChartYAxisItemLabelsPadding;
        rotation?: number | ChartYAxisItemLabelsRotation;
        skip?: number;
        step?: number;
        template?: string | Function;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartYAxisItemLine {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
    }

    interface ChartYAxisItemMajorGridLines {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartYAxisItemMajorTicks {
        color?: string;
        size?: number;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartYAxisItemMinorGridLines {
        color?: string;
        dashType?: string;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartYAxisItemMinorTicks {
        color?: string;
        size?: number;
        visible?: boolean;
        width?: number;
        step?: number;
        skip?: number;
    }

    interface ChartYAxisItemNotesDataItemIconBorder {
        color?: string;
        width?: number;
    }

    interface ChartYAxisItemNotesDataItemIcon {
        background?: string;
        border?: ChartYAxisItemNotesDataItemIconBorder;
        size?: number;
        type?: string;
        visible?: boolean;
    }

    interface ChartYAxisItemNotesDataItemLabelBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartYAxisItemNotesDataItemLabel {
        background?: string;
        border?: ChartYAxisItemNotesDataItemLabelBorder;
        color?: string;
        font?: string;
        template?: string | Function;
        visible?: boolean;
        rotation?: number;
        format?: string;
        text?: string;
        position?: string;
    }

    interface ChartYAxisItemNotesDataItemLine {
        width?: number;
        color?: string;
        length?: number;
    }

    interface ChartYAxisItemNotesDataItem {
        value?: any;
        position?: string;
        icon?: ChartYAxisItemNotesDataItemIcon;
        label?: ChartYAxisItemNotesDataItemLabel;
        line?: ChartYAxisItemNotesDataItemLine;
    }

    interface ChartYAxisItemNotesIconBorder {
        color?: string;
        width?: number;
    }

    interface ChartYAxisItemNotesIcon {
        background?: string;
        border?: ChartYAxisItemNotesIconBorder;
        size?: number;
        type?: string;
        visible?: boolean;
    }

    interface ChartYAxisItemNotesLabelBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartYAxisItemNotesLabel {
        background?: string;
        border?: ChartYAxisItemNotesLabelBorder;
        color?: string;
        font?: string;
        template?: string | Function;
        visible?: boolean;
        rotation?: number;
        format?: string;
        position?: string;
    }

    interface ChartYAxisItemNotesLine {
        dashType?: string;
        width?: number;
        color?: string;
        length?: number;
    }

    interface ChartYAxisItemNotes {
        position?: string;
        icon?: ChartYAxisItemNotesIcon;
        label?: ChartYAxisItemNotesLabel;
        line?: ChartYAxisItemNotesLine;
        data?: ChartYAxisItemNotesDataItem[];
        visual?: Function;
    }

    interface ChartYAxisItemPlotBand {
        color?: string;
        from?: number;
        opacity?: number;
        to?: number;
    }

    interface ChartYAxisItemTitleBorder {
        color?: string;
        dashType?: string;
        width?: number;
    }

    interface ChartYAxisItemTitleMargin {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartYAxisItemTitlePadding {
        bottom?: number;
        left?: number;
        right?: number;
        top?: number;
    }

    interface ChartYAxisItemTitle {
        background?: string;
        border?: ChartYAxisItemTitleBorder;
        color?: string;
        font?: string;
        margin?: ChartYAxisItemTitleMargin;
        padding?: ChartYAxisItemTitlePadding;
        position?: string;
        rotation?: number;
        text?: string;
        visible?: boolean;
        visual?: Function;
    }

    interface ChartYAxisItem {
        axisCrossingValue?: any | Date | any;
        background?: string;
        baseUnit?: string;
        color?: string;
        crosshair?: ChartYAxisItemCrosshair;
        labels?: ChartYAxisItemLabels;
        line?: ChartYAxisItemLine;
        majorGridLines?: ChartYAxisItemMajorGridLines;
        minorGridLines?: ChartYAxisItemMinorGridLines;
        minorTicks?: ChartYAxisItemMinorTicks;
        majorTicks?: ChartYAxisItemMajorTicks;
        majorUnit?: number;
        max?: any;
        min?: any;
        minorUnit?: number;
        name?: string;
        narrowRange?: boolean;
        pane?: string;
        plotBands?: ChartYAxisItemPlotBand[];
        reverse?: boolean;
        title?: ChartYAxisItemTitle;
        type?: string;
        visible?: boolean;
        notes?: ChartYAxisItemNotes;
    }

    interface ChartZoomableMousewheel {
        lock?: string;
    }

    interface ChartZoomableSelection {
        key?: string;
        lock?: string;
    }

    interface ChartZoomable {
        mousewheel?: boolean | ChartZoomableMousewheel;
        selection?: boolean | ChartZoomableSelection;
    }

    interface ChartSeriesClickEventSeries {
        type?: string;
        name?: string;
        data?: any;
    }

    interface ChartSeriesHoverEventSeries {
        type?: string;
        name?: string;
        data?: any;
    }

    interface ChartSeriesOverEventSeries {
        type?: string;
        name?: string;
        data?: any;
    }

    interface ChartSeriesLeaveEventSeries {
        type?: string;
        name?: string;
        data?: any;
    }

    interface ChartOptions {
        name?: string;
        autoBind?: boolean;
        axisDefaults?: ChartAxisDefaults;
        categoryAxis?: ChartCategoryAxisItem | ChartCategoryAxisItem[];
        chartArea?: ChartChartArea;
        dataSource?: any | any | kendo.data.DataSource;
        legend?: ChartLegend;
        panes?: ChartPane[];
        pannable?: boolean | ChartPannable;
        pdf?: ChartPdf;
        persistSeriesVisibility?: boolean;
        plotArea?: ChartPlotArea;
        renderAs?: string;
        series?: ChartSeriesItem[];
        seriesColors?: any;
        seriesDefaults?: ChartSeriesDefaults;
        theme?: string;
        title?: string | ChartTitle;
        tooltip?: ChartTooltip;
        transitions?: boolean;
        valueAxis?: ChartValueAxisItem | ChartValueAxisItem[];
        xAxis?: ChartXAxisItem | ChartXAxisItem[];
        yAxis?: ChartYAxisItem | ChartYAxisItem[];
        zoomable?: boolean | ChartZoomable;
        axisLabelClick?(e: ChartAxisLabelClickEvent): void;
        dataBound?(e: ChartDataBoundEvent): void;
        drag?(e: ChartDragEvent): void;
        dragEnd?(e: ChartDragEndEvent): void;
        dragStart?(e: ChartDragStartEvent): void;
        legendItemClick?(e: ChartLegendItemClickEvent): void;
        legendItemHover?(e: ChartLegendItemHoverEvent): void;
        legendItemLeave?(e: ChartLegendItemLeaveEvent): void;
        noteClick?(e: ChartNoteClickEvent): void;
        noteHover?(e: ChartNoteHoverEvent): void;
        noteLeave?(e: ChartNoteLeaveEvent): void;
        paneRender?(e: ChartPaneRenderEvent): void;
        plotAreaClick?(e: ChartPlotAreaClickEvent): void;
        plotAreaHover?(e: ChartPlotAreaHoverEvent): void;
        plotAreaLeave?(e: ChartPlotAreaLeaveEvent): void;
        render?(e: ChartRenderEvent): void;
        select?(e: ChartSelectEvent): void;
        selectEnd?(e: ChartSelectEndEvent): void;
        selectStart?(e: ChartSelectStartEvent): void;
        seriesClick?(e: ChartSeriesClickEvent): void;
        seriesHover?(e: ChartSeriesHoverEvent): void;
        seriesOver?(e: ChartSeriesOverEvent): void;
        seriesLeave?(e: ChartSeriesLeaveEvent): void;
        zoom?(e: ChartZoomEvent): void;
        zoomEnd?(e: ChartZoomEndEvent): void;
        zoomStart?(e: ChartZoomStartEvent): void;
    }

    interface ChartEvent {
        sender: Chart;
        preventDefault: Function;
        isDefaultPrevented(): boolean;
    }

    interface ChartAxisLabelClickEvent extends ChartEvent {
        axis?: any;
        dataItem?: any;
        element?: any;
        index?: any;
        text?: string;
        value?: any;
    }

    interface ChartDataBoundEvent extends ChartEvent {
    }

    interface ChartDragEvent extends ChartEvent {
        axisRanges?: any;
        originalEvent?: any;
    }

    interface ChartDragEndEvent extends ChartEvent {
        axisRanges?: any;
        originalEvent?: any;
    }

    interface ChartDragStartEvent extends ChartEvent {
        axisRanges?: any;
        originalEvent?: any;
    }

    interface ChartLegendItemClickEvent extends ChartEvent {
        pointIndex?: number;
        series?: any;
        seriesIndex?: number;
        text?: string;
        element?: any;
    }

    interface ChartLegendItemHoverEvent extends ChartEvent {
        element?: any;
        pointIndex?: number;
        series?: any;
        seriesIndex?: number;
        text?: string;
    }

    interface ChartLegendItemLeaveEvent extends ChartEvent {
        element?: any;
        pointIndex?: number;
        series?: any;
        seriesIndex?: number;
        text?: string;
    }

    interface ChartNoteClickEvent extends ChartEvent {
        category?: any;
        dataItem?: any;
        element?: any;
        series?: any;
        value?: any;
        visual?: any;
    }

    interface ChartNoteHoverEvent extends ChartEvent {
        category?: any;
        dataItem?: any;
        element?: any;
        series?: any;
        value?: any;
        visual?: any;
    }

    interface ChartNoteLeaveEvent extends ChartEvent {
        category?: any;
        dataItem?: any;
        element?: any;
        series?: any;
        value?: any;
        visual?: any;
    }

    interface ChartPaneRenderEvent extends ChartEvent {
        pane?: kendo.dataviz.ChartPane;
        name?: string;
        index?: number;
    }

    interface ChartPlotAreaClickEvent extends ChartEvent {
        category?: any;
        element?: any;
        originalEvent?: any;
        value?: any;
        x?: any;
        y?: any;
    }

    interface ChartPlotAreaHoverEvent extends ChartEvent {
        category?: any;
        element?: any;
        originalEvent?: any;
        value?: any;
        x?: any;
        y?: any;
    }

    interface ChartPlotAreaLeaveEvent extends ChartEvent {
    }

    interface ChartRenderEvent extends ChartEvent {
    }

    interface ChartSelectEvent extends ChartEvent {
        axis?: any;
        from?: any;
        to?: any;
    }

    interface ChartSelectEndEvent extends ChartEvent {
        axis?: any;
        from?: any;
        to?: any;
    }

    interface ChartSelectStartEvent extends ChartEvent {
        axis?: any;
        from?: any;
        to?: any;
    }

    interface ChartSeriesClickEvent extends ChartEvent {
        category?: any;
        dataItem?: any;
        element?: any;
        originalEvent?: any;
        percentage?: any;
        series?: ChartSeriesClickEventSeries;
        stackValue?: any;
        value?: any;
    }

    interface ChartSeriesHoverEvent extends ChartEvent {
        category?: any;
        categoryPoints?: any;
        dataItem?: any;
        element?: any;
        originalEvent?: any;
        percentage?: any;
        series?: ChartSeriesHoverEventSeries;
        stackValue?: any;
        value?: any;
    }

    interface ChartSeriesOverEvent extends ChartEvent {
        category?: any;
        dataItem?: any;
        element?: any;
        originalEvent?: any;
        percentage?: any;
        series?: ChartSeriesOverEventSeries;
        stackValue?: any;
        value?: any;
    }

    interface ChartSeriesLeaveEvent extends ChartEvent {
        category?: any;
        dataItem?: any;
        element?: any;
        originalEvent?: any;
        percentage?: any;
        series?: ChartSeriesLeaveEventSeries;
        stackValue?: any;
        value?: any;
    }

    interface ChartZoomEvent extends ChartEvent {
        axisRanges?: any;
        delta?: number;
        originalEvent?: any;
    }

    interface ChartZoomEndEvent extends ChartEvent {
        axisRanges?: any;
        originalEvent?: any;
    }

    interface ChartZoomStartEvent extends ChartEvent {
        axisRanges?: any;
        originalEvent?: any;
    }
}

interface HTMLElement {
    kendoBindingTarget: kendo.data.BindingTarget;
}

interface JQueryXHR { }

interface JQueryEventObject { }

interface JQueryPromise<T> { }

interface JQueryAjaxSettings { }

interface JQuery {
    data(key: any): any;

    kendoChart(): JQuery;
    kendoChart(options: kendo.dataviz.ui.ChartOptions): JQuery;
}