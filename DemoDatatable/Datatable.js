import http from '../Configuration/HttpClient/HttpClient';
import SwalToast from './SwalToast';
import constants from '../Configuration/Constant/Constant';

const { titlesToast } = constants;


export class ColumnTable {
    title = '';
    columnData;
    width;
    classC;
    renderHTML;

    constructor(titleP, columnDataP, widthP, classP, renderHtmlP) {
        this.title = titleP;
        this.columnData = columnDataP;
        this.width = widthP;
        this.classC = classP;
        this.renderHTML = renderHtmlP;
    }
}


export class Datatable {


    numberOfEntries;
    elementContainer;
    element;
    masterData;
    data;
    columns;
    textSearch;
    url;
    events;
    params;
    masterParams;
    pagination;
    responseData;
    fnRenderData;
    fnRenderDataUrl;

    constructor(selector, selectorContainer) {


        this.elementContainer = document.querySelector(selectorContainer);
        this.element = document.querySelector(selector);
        this.numberOfEntries = 5;
        this.columns = [];
        this.data = [];
        this.masterData = [];
        this.events = [];
        this.params = {};
        this.textSearch = '';

        this.pagination = {
            nroPage: 1,
            paginationVisiblePages: 5,
            totalPage: 0
        }

        this.responseData = {
            cantidadTotal: 0,
            listadoData: []
        };

        this.initEventNumberEntries();
        this.initEventInputSearch();
    }

    setColumns(columns) {
        return new Promise((resolve) => {
            this.columns = columns;
            this.renderHeaders();
            resolve(true);
        });
    }

    setData(data, fn) {

        return new Promise((resolve) => {
            if(data){
                this.masterData = [...data];
            }
            else{
                this.masterData = null;
            }
            
            this.data = this.masterData;
            this.fnRenderData = fn;
            resolve(true);
        });
    }

    initTable() {

        return new Promise(async (resolve) => {

            if (this.url) {
                await this.getCallDataUrl();
            }

            this.renderPagination();
            this.renderInfoTextPagination();
            this.renderRowsData();
            this.asignEventListener();
            this.executeFns();
            resolve(true);
        });
    }

    reload() {

        return new Promise(async (resolve) => {

            this.pagination.nroPage = 1;

            this.mappingParameter();

            if (this.url) {
                await this.getCallDataUrl();
            }

            this.renderPagination();
            this.renderInfoTextPagination();
            this.renderRowsData();
            this.asignEventListener();

            this.executeFns();

            resolve(true);
        });
    }

    setUrl(url, params, fn) {

        return new Promise((resolve) => {

            this.url = url;
            this.masterParams = params;
            this.mappingParameter();         
            this.fnRenderDataUrl = fn;
            resolve(true);
        });
    }

    replaceObject(field, value, objectReplace) {
        return new Promise((resolve) => {
            const dataMaster = [...this.masterData];
            this.masterData = dataMaster.map(data => data[field] == value ? objectReplace : data);
            this.data = [...this.masterData];

            this.renderPagination();
            this.renderRowsData();
            this.asignEventListener();
            resolve(true);
        });
    }

    removeRow(field, value) {
        return new Promise((resolve) => {

            const dataMaster = [...this.masterData];
            const dataResult = dataMaster.find(data => data[field] == value);
            const index = dataMaster.indexOf(dataResult);
            dataMaster.splice(index, 1);

            this.masterData = [...dataMaster];
            this.data = [...this.masterData];

            this.renderPagination();
            this.renderRowsData();
            this.asignEventListener();
            resolve(true);
        })
    }

    getDataOfRow(field, value) {
        return new Promise((resolve) => {

            const dataResult = this.masterData.find(data => data[field] == value);
            resolve(dataResult);
        });
    }

    getDataMaster() {
        return new Promise((resolve) => {
            resolve(this.masterData);
        });
    }

    addRowAfterBegin(item) {
        return new Promise((resolve) => {

            this.masterData.unshift(item);
            this.data = [...this.masterData];

            this.renderPagination();
            this.renderRowsData();
            this.asignEventListener();
            resolve(true);
        })
    }

    addRowBeforeEnd(item) {
        return new Promise((resolve) => {

            this.masterData.push(item);
            this.data = [...this.masterData];

            this.renderPagination();
            this.renderRowsData();
            this.asignEventListener();
            resolve(true);
        })
    }

    setAddEventListenerElement(typeEvent, nameClass, callBack) {

        this.events.push({ typeEvent, nameClass, callBack });
    }




    //FUNCIONES INTERNAS

    getNEntries() {
        return this.elementContainer.querySelector('select.n-entries').value;
    }

    mappingParameter() {

        return new Promise((resolve) => {

            let paramsTemp = { ...this.masterParams };

            paramsTemp = Object.keys(paramsTemp).reduce((acc, ele) => ({ ...acc, [ele]: paramsTemp[ele].value }), ({}));

            paramsTemp = {
                ...paramsTemp,
                textSearch: this.textSearch,
                nroPage: this.pagination.nroPage,
                numberOfEntries: this.numberOfEntries === 'Todo' ? -1 : this.numberOfEntries
            }

            this.params = paramsTemp;
            resolve(true);
        });
    }

    asignEventListener() {

        return new Promise((resolve) => {

            if (this.events.length > 0) {

                this.events.forEach(event => {
                    const { typeEvent, nameClass, callBack } = event;

                    const array = Array.from(this.element.querySelectorAll(nameClass));
                    array.forEach(element => {
                        element.addEventListener(typeEvent, callBack);
                    });
                });
            }

            resolve(true);
        })

    }

    renderHeaders() {

        return new Promise((resolve) => {

            const theadTemp = this.element.querySelector('thead');
            if (theadTemp) theadTemp.remove();

            let ths = "";
            const tr = document.createElement('tr');
            const thead = document.createElement('thead');

            this.columns.forEach(column => {
                ths += `<th style='width:${column.width};white-space: nowrap;'>${column.title}</th>`;
            });

            tr.innerHTML = ths;
            thead.appendChild(tr);
            this.element.appendChild(thead);
            resolve(true);
        })

    }

    renderRowsData() {

        return new Promise((resolve) => {
            let tbody = this.element.querySelector('tbody');

            if (tbody)
                tbody.innerHTML = '';
            else
                tbody = document.createElement('tbody');


            if (this.data.length > 0) {

                let copyData = [...this.data];

                if (!this.url) {

                    this.numberOfEntries = this.getNEntries();
                    this.numberOfEntries = this.numberOfEntries === 'Todo' ? this.data.length : this.numberOfEntries;

                    copyData = this.data.slice(this.numberOfEntries * (this.pagination.nroPage - 1), this.numberOfEntries * this.pagination.nroPage);

                }

                copyData.forEach(dataRow => {

                    const tr = document.createElement('tr');
                    this.columns.forEach(column => {
                        const { columnData, classC, renderHTML } = column;
                        const td = document.createElement('td');
                        td.style.whiteSpace = 'nowrap'

                        if (classC)
                            td.classList.add(...classC);

                        if (columnData) {

                            const columnDataRef = columnData;
                            const splitColumnData = columnDataRef.split('.');
                            let dataTemp = { ...dataRow };
                            let value = '';

                            if (splitColumnData.length > 1) {

                                for (let i = 0; i < splitColumnData.length; i++) {

                                    const attributo = splitColumnData[i];

                                    if (typeof (dataTemp[attributo]) === 'object') {
                                        dataTemp = dataTemp[attributo];
                                    } else {
                                        value = dataTemp[attributo] || '';
                                    }
                                }
                            }
                            else {
                                value = dataRow[columnData] || '';
                            }

                            td.innerText = value;
                        }
                        else if (renderHTML)
                            td.innerHTML = renderHTML(dataRow);
                        else
                            td.innerHTML = `<span class="available"></span>`;

                        tr.appendChild(td);
                    });

                    tbody.appendChild(tr);
                });

            }
            else {
                const tr = document.createElement('tr');
                const td = document.createElement('td');
                td.colSpan = this.columns.length;
                td.classList.add('text-center')
                td.innerText = "No se encontraron registros";

                tr.appendChild(td)
                tbody.appendChild(tr);
            }

            this.element.appendChild(tbody);

            resolve(true);
        })



    }

    renderInfoTextPagination() {

        return new Promise((resolve) => {
            const infoPagination = this.elementContainer.querySelector('.info-pagination');

            let ofRegister = 0
            let toRegisterCalcule = 0;
            let toRegister = 0
            let ofTotalRegister = 0;


            if (this.url) {

                ofRegister = this.responseData.listadoData.length <= 0 ? 0 : this.pagination.nroPage === 1 ? 1 : (this.numberOfEntries * (this.pagination.nroPage - 1)) + 1;
                toRegisterCalcule = this.numberOfEntries * this.pagination.nroPage;
                toRegister = toRegisterCalcule < this.responseData.cantidadTotal ? toRegisterCalcule : this.responseData.cantidadTotal;
                ofTotalRegister = this.responseData.cantidadTotal;

            } else {

                ofRegister = this.data.length <= 0 ? 0 : this.pagination.nroPage === 1 ? 1 : (this.numberOfEntries * (this.pagination.nroPage - 1)) + 1;
                toRegisterCalcule = this.numberOfEntries * this.pagination.nroPage;
                toRegister = toRegisterCalcule < this.data.length ? toRegisterCalcule : this.data.length;
                ofTotalRegister = this.data.length;
            }

            infoPagination.querySelector('span').innerText = `Mostrando ${ofRegister} a ${toRegister} de ${ofTotalRegister} registros.`;

            resolve(true);
        })

    }

    renderPagination() {

        return new Promise((resolve) => {

            const pagination = this.elementContainer.querySelector('.pages');
            pagination.innerHTML = '';
            const ul = document.createElement('ul');

            ul.appendChild(this.createPageLi('prev', '<', 'btnPrev'));
            ul.appendChild(this.createPageLi(null, '1', 'active'));

            if (this.numberOfEntries !== 'Todo') {

                if (this.url)
                    this.pagination.totalPage = Math.ceil(parseInt(this.responseData.cantidadTotal) / parseInt(this.numberOfEntries));
                else
                    this.pagination.totalPage = Math.ceil(parseInt(this.data.length) / parseInt(this.numberOfEntries));


                if (this.pagination.totalPage < this.pagination.paginationVisiblePages) {

                    for (let num = 2; num <= this.pagination.totalPage; num++) {

                        ul.appendChild(this.createPageLi(null, num));
                    }
                }
                else {

                    for (let num = 2; num <= this.pagination.paginationVisiblePages; num++) {
                        ul.appendChild(this.createPageLi(null, num));
                    }
                    for (let num = this.pagination.paginationVisiblePages + 1; num <= this.pagination.totalPage; num++) {

                        ul.appendChild(this.createPageLi(null, num, 'd-none'));
                    }
                }

                ul.appendChild(this.createPageLi('next', '>', 'btnNext'));
                pagination.appendChild(ul);
            }

            resolve(true);
        })
    }

    ///////////////////////////////


    //EVENTOS

    initEventNumberEntries() {

        const nEntries = this.elementContainer.querySelector('.n-entries');

        nEntries.addEventListener('change', async (e) => {

            this.numberOfEntries = e.target.value;
            this.pagination.nroPage = 1;
            await this.mappingParameter();
            await this.initTable();

        });
    }

    initEventInputSearch() {

        const txtSearch = this.elementContainer.querySelector('.txtSearch');

        txtSearch.addEventListener('input', async (e) => {
            this.textSearch = e.target.value;
            if (this.url) {

                if (this.textSearch.length > 2 || this.textSearch.length == 0)
                    await this.mappingParameter();

            } else {

                if (this.textSearch.length > 2 || this.textSearch.length == 0) {
                    const copyData = [...this.masterData];
                    const newFilterData = [];
                    const columnsHeaders = this.columns.map(column => column.columnData);
                    copyData.forEach(dataRow => {

                        const attributes = Object.keys(dataRow);

                        for (let i = 0; i < attributes.length; i++) {

                            const attr = attributes[i];
                            if (columnsHeaders.includes(attr)) {
                                if (dataRow[attr].toString().includes(this.textSearch)) {
                                    newFilterData.push(dataRow);
                                    break;
                                }
                            }
                        }
                    });

                    this.data = [...newFilterData];
                }
                else {
                    this.data = [...this.masterData];
                }
            }

            this.pagination.nroPage = 1;

            if (this.textSearch.length > 2 || this.textSearch.length == 0) {
                await this.initTable();
            }


        });
    }

    //////////////////////////////


    //PAGINATION

    activePage(element, numOfEntries) {

        return new Promise(async (resolve) => {

            const currentPage =  this.elementContainer.querySelector('.pages button.active');

            let nextLink = this.elementContainer.querySelector('button.btnNext');
            let prevLink = this.elementContainer.querySelector('button.btnPrev');
            let nextTab = currentPage.closest('li').nextSibling.querySelector('button')
            let prevTab = currentPage.closest('li').previousSibling.querySelector('button')
            currentPage.classList.remove("active");

            if (element === 'next') {

                if (parseInt(nextTab.textContent).toString() === 'NaN') {

                    nextTab.closest('li').previousSibling.querySelector('button').classList.add("active")
                    nextTab.onclick = () => false;
                }
                else {
                    nextTab.classList.add("active");
                    await this.renderRowsDataPagination(parseInt(nextTab.textContent));
                    if (prevLink.onclick.toString().includes("() => false")) {
                        prevLink.onclick = () => this.activePage('prev', this.numberOfEntries);
                    }
                    if (nextTab.classList.contains('d-none')) {
                        nextTab.classList.remove('d-none')
                        nextTab.closest('li').classList.remove('d-none');
                        this.hideFromBening(prevLink.closest('li').nextSibling.querySelector('button'));
                    }
                }
            } else if (element === "prev") {

                if (parseInt(prevTab.textContent).toString() === 'NaN') {
                    prevTab.closest('li').nextSibling.querySelector('button').classList.add("active")
                    prevTab.onclick = () => false;
                } else {
                    prevTab.classList.add("active");
                    await this.renderRowsDataPagination(parseInt(prevTab.textContent));

                    if (nextLink.onclick.toString().includes("() => false")) {
                        nextLink.onclick = () => this.activePage('next', this.numberOfEntries);
                    }
                    if (prevTab.classList.contains('d-none')) {
                        prevTab.classList.remove('d-none')
                        prevTab.closest('li').classList.remove('d-none');
                        this.hideFromEnd(nextLink.closest('li').previousSibling.querySelector('button'));
                    }
                }
            } else {
                element.classList.add("active");
                await this.renderRowsDataPagination(parseInt(element.textContent));

                if (prevLink.onclick.toString().includes("() => false")) {
                    prevLink.onclick = () => this.activePage('prev', this.numberOfEntries);
                }
                if (nextLink.onclick.toString().includes("() => false")) {
                    nextLink.onclick = () => this.activePage('next', this.numberOfEntries);
                }
            }

            resolve(true);
        })

    }

    hideFromBening(element) {

        if (!element.classList.contains('d-none')) {
            element.classList.add('d-none');
            element.closest('li').classList.add('d-none');
        } else {
            this.hideFromBening(element.closest('li').nextSibling.querySelector('button'));
        }
    }

    hideFromEnd(element) {

        if (!element.classList.contains('d-none')) {
            element.classList.add('d-none');
            element.closest('li').classList.add('d-none');
        } else {
            this.hideFromEnd(element.closest('li').previousSibling.querySelector('button'));
        }
    }

    async renderRowsDataPagination(nroPage) {

        this.pagination.nroPage = nroPage;

        if (this.url) {

            await this.mappingParameter();
            await this.getCallDataUrl();
        }

        this.renderInfoTextPagination();
        this.renderRowsData();
        this.asignEventListener();

        this.executeFns();
    }

    executeFns(){

        if(this.fnRenderDataUrl && this.url)
            this.fnRenderDataUrl();

        if(this.fnRenderData && !this.url)
            this.fnRenderData();
    }

    createPageLi(param, num, classbtn) {
        const li = document.createElement('li');
        const button = document.createElement('button');

        if (classbtn) {
            button.classList.add(classbtn);

            if (classbtn.includes('none'))
                li.classList.add(classbtn)
        }

        if (!param)
            param = button;

        button.onclick = () => this.activePage(param, this.numberOfEntries);
        button.innerHTML = num;
        li.appendChild(button);
        return li;
    }

    /////////////////////////////

    //FETCH

    async getCallDataUrl() {

        try {

            const result = await http.mGet(this.url, this.params, null, true);
            const { success, message } = result;

            if (success) {

                const { cantidadTotal, listado } = result.result;

                await this.setData(listado);
                this.responseData.cantidadTotal = cantidadTotal;
                this.responseData.listadoData = listado;
            }
            else {
                SwalToast.showToastError(message, titlesToast.ocurrioError)
            }

        } catch (e) {
            console.log(e)
            SwalToast.showToastError(e, titlesToast.error)
        }
    }

    /////////////////////////////


}