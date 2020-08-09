// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function confirmDelete(idUsuario, name) {
    var url = '/Home/delete?idUser=' + idUsuario;

    $('#deleteModal').remove();

    $('#modal').append('<div class="modal fade" id="deleteModal" tabindex="-1" aria-labelledby="deleteModalLabel" aria-hidden="true">\n' +
        '                    <div class="modal-dialog">\n' +
        '                        <div class="modal-content">\n' +
        '                            <div class="modal-header">\n' +
        '                                <h5 class="modal-title" id="deleteModalLabel">Delete User</h5>\n' +
        '                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">\n' +
        '                                    <span aria-hidden="true">&times;</span>\n' +
        '                                </button>\n' +
        '                            </div>\n' +
        '                            <div class="modal-body">\n' +
        '                                <p>Are you sure to delete the user ' + name + '</p>\n' +
        '                            </div>\n' +
        '                            <div class="modal-footer">\n' +
        '                                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>\n' +
        '                                <a class="btn btn-danger" href="' + url + '">Delete</a>\n' +
        '                            </div>\n' +
        '                        </div>\n' +
        '                    </div>\n' +
        '                </div>');


}